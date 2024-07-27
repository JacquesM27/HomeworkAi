using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Events.SuspiciousPrompts;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;

public sealed record SentenceWithVerbToCompleteBasedOnInfinitiveQuery(int AmountOfSentences)
    : ExerciseQueryBase, IQuery<OpenAnswerExerciseResponseSentenceWithVerbToCompleteBasedOnInfinitive>;

internal sealed class SentenceWithVerbToCompleteBasedOnInfinitiveQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService,
    IEventDispatcher eventDispatcher)
    : IQueryHandler<SentenceWithVerbToCompleteBasedOnInfinitiveQuery,
        OpenAnswerExerciseResponseSentenceWithVerbToCompleteBasedOnInfinitive>
{
    public async Task<OpenAnswerExerciseResponseSentenceWithVerbToCompleteBasedOnInfinitive> HandleAsync(
        SentenceWithVerbToCompleteBasedOnInfinitiveQuery query)
    {
        var queryAsString = objectSamplerService.GetStringValues(query);
        var suspiciousPromptResponse = await openAiExerciseService.ValidateAvoidingOriginTopic(queryAsString);
        if (suspiciousPromptResponse.IsSuspicious)
        {
            await eventDispatcher.PublishAsync(new SuspiciousPromptInjected(suspiciousPromptResponse));
            throw new PromptInjectionException(suspiciousPromptResponse.Reasons);
        }

        var exerciseJsonFormat =
            objectSamplerService.GetSampleJson(typeof(SentenceWithVerbToCompleteBasedOnInfinitive));

        var prompt =
            $"1. This is open answer - sentences with verb to complete based on infinitive exercise. This means that need to generate {query.AmountOfSentences} sentences with a verb to complete based on the infinitive. Replace the place of the verb in the sentence with ____.";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;

        var response =
            await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<SentenceWithVerbToCompleteBasedOnInfinitive>(response);

        var result = new OpenAnswerExerciseResponseSentenceWithVerbToCompleteBasedOnInfinitive()
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

        await eventDispatcher.PublishAsync(
            new OpenAnswerExerciseResponseSentenceWithVerbToCompleteBasedOnInfinitiveGenerated(result));
        return result;
    }
}