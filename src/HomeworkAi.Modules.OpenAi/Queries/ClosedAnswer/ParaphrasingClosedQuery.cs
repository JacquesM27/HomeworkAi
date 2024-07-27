using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Events.SuspiciousPrompts;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.ClosedAnswer;

public sealed record ParaphrasingClosedQuery(int AmountOfSentences)
    : ExerciseQueryBase, IQuery<ClosedAnswerExerciseResponseParaphrasing>;

public sealed class ParaphrasingClosedQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService,
    IEventDispatcher eventDispatcher)
    : IQueryHandler<ParaphrasingClosedQuery, ClosedAnswerExerciseResponseParaphrasing>
{
    public async Task<ClosedAnswerExerciseResponseParaphrasing> HandleAsync(ParaphrasingClosedQuery query)
    {
        var queryAsString = objectSamplerService.GetStringValues(query);
        var suspiciousPromptResponse = await openAiExerciseService.ValidateAvoidingOriginTopic(queryAsString);
        if (suspiciousPromptResponse.IsSuspicious)
        {
            await eventDispatcher.PublishAsync(new SuspiciousPromptInjected(suspiciousPromptResponse));
            throw new PromptInjectionException(suspiciousPromptResponse.Reasons);
        }

        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(ParaphrasingClosed));

        var prompt =
            $"1. This is closed answer - paraphrasing exercise. This means that you need to generate {query.AmountOfSentences} sentences in {query.TargetLanguage} and 3 to 4 paraphrases but only 1 can be correct.";

        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;

        var response =
            await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<ParaphrasingClosed>(response);

        var result = new ClosedAnswerExerciseResponseParaphrasing()
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

        await eventDispatcher.PublishAsync(new ClosedAnswerExerciseResponseParaphrasingGenerated(result));
        return result;
    }
}