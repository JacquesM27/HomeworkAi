﻿using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;

public sealed record WordMeaningOpenQuery(int AmountOfSentences)
    : ExerciseQueryBase, IQuery<OpenAnswerExerciseResponse<WordMeaningOpen>>;
    
public sealed class WordMeaningOpenQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService)
    : IQueryHandler<WordMeaningOpenQuery, OpenAnswerExerciseResponse<WordMeaningOpen>>
{
    public async Task<OpenAnswerExerciseResponse<WordMeaningOpen>> HandleAsync(WordMeaningOpenQuery openQuery)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(WordMeaningOpen));

        var prompt =
            $"1. This is open answer - word meaning exercise. This means that you need to generate words in {openQuery.TargetLanguage} according to the following requirements.";

        prompt += promptFormatter.FormatExerciseBaseData(openQuery);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;

        var response =
            await openAiExerciseService.PromptForExercise(prompt, openQuery.MotherLanguage, openQuery.TargetLanguage);

        var exercise = deserializerService.Deserialize<WordMeaningOpen>(response);

        var result = new OpenAnswerExerciseResponse<WordMeaningOpen>()
        {
            Exercise = exercise,
            ExerciseHeaderInMotherLanguage = openQuery.ExerciseHeaderInMotherLanguage,
            MotherLanguage = openQuery.MotherLanguage,
            TargetLanguage = openQuery.TargetLanguage,
            TargetLanguageLevel = openQuery.TargetLanguageLevel,
            TopicsOfSentences = openQuery.TopicsOfSentences,
            GrammarSection = openQuery.GrammarSection,
            AmountOfSentences = openQuery.AmountOfSentences
        };

        //TODO: add event/rabbit with exercise.
        return result;
    }
}


    
    
    