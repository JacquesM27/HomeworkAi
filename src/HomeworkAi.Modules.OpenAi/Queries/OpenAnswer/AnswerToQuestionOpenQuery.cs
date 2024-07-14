﻿using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Events.SuspiciousPrompts;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;

public sealed record AnswerToQuestionOpenQuery(int AmountOfSentences) 
    : ExerciseQueryBase, IQuery<OpenAnswerExerciseResponse<AnswerToQuestionOpen>>;

internal sealed class AnswerToQuestionOpenQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService, IDeserializerService deserializerService,
    IEventDispatcher eventDispatcher)
    : IQueryHandler<AnswerToQuestionOpenQuery, OpenAnswerExerciseResponse<AnswerToQuestionOpen>>
{
    public async Task<OpenAnswerExerciseResponse<AnswerToQuestionOpen>> HandleAsync(AnswerToQuestionOpenQuery query)
    {
        var queryAsString = objectSamplerService.GetStringValues(query);
        var suspiciousPromptResponse = await openAiExerciseService.ValidateAvoidingOriginTopic(queryAsString);
        if (suspiciousPromptResponse.IsSuspicious)
        {
            await eventDispatcher.PublishAsync(new SuspiciousPromptInjected(suspiciousPromptResponse));
            throw new PromptInjectionException(suspiciousPromptResponse.Reasons);
        }
        
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(AnswerToQuestionOpen));
        
        var prompt = $"1. This is open answer exercise. This means that need to generate {query.AmountOfSentences} questions in {query.TargetLanguage} (questions, not answers) according to the following grammatical requirements. The generated questions are for students to answer.";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<AnswerToQuestionOpen>(response);

        var result = new OpenAnswerExerciseResponse<AnswerToQuestionOpen>()
        {
            Exercise = exercise,
            ExerciseHeaderInMotherLanguage = query.ExerciseHeaderInMotherLanguage,
            MotherLanguage = query.MotherLanguage,
            TargetLanguage = query.TargetLanguage,
            TargetLanguageLevel = query.TargetLanguageLevel,
            TopicsOfSentences = query.TopicsOfSentences,
            GrammarSection = query.GrammarSection,
            AmountOfSentences = query.AmountOfSentences
        };

        await eventDispatcher.PublishAsync(new OpenAnswerExerciseGenerated<AnswerToQuestionOpen>(result));
        return result;
    }
}


