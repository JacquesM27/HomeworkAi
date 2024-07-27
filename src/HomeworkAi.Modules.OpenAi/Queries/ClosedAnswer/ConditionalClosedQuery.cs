using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Events.SuspiciousPrompts;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.ClosedAnswer;

public sealed record ConditionalClosedQuery(
    int AmountOfSentences,
    bool TranslateFromMotherLanguage,
    bool ZeroConditional,
    bool FirstConditional,
    bool SecondConditional,
    bool ThirdConditional)
    : ExerciseQueryBase, IQuery<ClosedAnswerExerciseResponseConditional>;

public sealed class ConditionalClosedQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService,
    IEventDispatcher eventDispatcher)
    : IQueryHandler<ConditionalClosedQuery, ClosedAnswerExerciseResponseConditional>
{
    public async Task<ClosedAnswerExerciseResponseConditional> HandleAsync(ConditionalClosedQuery query)
    {
        var queryAsString = objectSamplerService.GetStringValues(query);
        var suspiciousPromptResponse = await openAiExerciseService.ValidateAvoidingOriginTopic(queryAsString);
        if (suspiciousPromptResponse.IsSuspicious)
        {
            await eventDispatcher.PublishAsync(new SuspiciousPromptInjected(suspiciousPromptResponse));
            throw new PromptInjectionException(suspiciousPromptResponse.Reasons);
        }

        var roundedAmountOfSentences = RoundedAmountOfSentences(query);

        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(ConditionalClosed));

        var prompt =
            $"1. This is closed answer - conditional exercise. This means that you need to generate {TotalAmountOfSentences(query)} sentences ({roundedAmountOfSentences} per conditional list) in {(query.TranslateFromMotherLanguage ? query.MotherLanguage : query.TargetLanguage)} and for every sentence 3-4 translations in {(query.TranslateFromMotherLanguage ? query.TargetLanguage : query.MotherLanguage)} but only one grammatically correct (other answers must have grammatical errors). Sentences must be in the indicated conditional modes - {(query.ZeroConditional ? "zero, " : "")}{(query.FirstConditional ? "first, " : "")}{(query.SecondConditional ? "second, " : "")}{(query.ThirdConditional ? "third" : "")} - in JSON format you have list for each mode."; //", complete only those lists that were mentioned in the previous sentence.";

        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;

        var response =
            await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<ConditionalClosed>(response);

        var result = new ClosedAnswerExerciseResponseConditional()
        {
            Exercise = exercise,
            ExerciseHeaderInMotherLanguage = query.ExerciseHeaderInMotherLanguage,
            MotherLanguage = query.MotherLanguage,
            TargetLanguage = query.TargetLanguage,
            TargetLanguageLevel = query.TargetLanguageLevel,
            TopicsOfSentences = query.TopicsOfSentences,
            GrammarSection = query.GrammarSection,
            AmountOfSentences = query.AmountOfSentences,
            TranslateFromMotherLanguage = query.TranslateFromMotherLanguage,
            ZeroConditional = query.ZeroConditional,
            FirstConditional = query.FirstConditional,
            SecondConditional = query.SecondConditional,
            ThirdConditional = query.ThirdConditional
        };

        await eventDispatcher.PublishAsync(new ClosedAnswerExerciseResponseConditionalGenerated(result));
        return result;
    }

    private static int RoundedAmountOfSentences(ConditionalClosedQuery query)
    {
        bool[] conditions =
            [query.ZeroConditional, query.FirstConditional, query.SecondConditional, query.ThirdConditional];
        var conditionalDenominator = conditions.Count(c => c);
        var amountOfSentences = (double)query.AmountOfSentences / conditionalDenominator;
        var roundedAmountOfSentences = (int)Math.Ceiling(amountOfSentences);
        return roundedAmountOfSentences;
    }

    private static int TotalAmountOfSentences(ConditionalClosedQuery query)
    {
        bool[] conditions =
            [query.ZeroConditional, query.FirstConditional, query.SecondConditional, query.ThirdConditional];
        var conditionalDenominator = conditions.Count(c => c);
        var amountOfSentences = (double)query.AmountOfSentences / conditionalDenominator;
        var roundedAmountOfSentences = (int)Math.Ceiling(amountOfSentences);
        return roundedAmountOfSentences * conditionalDenominator;
    }
}