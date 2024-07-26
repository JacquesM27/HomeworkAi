using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Events.SuspiciousPrompts;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.ClosedAnswer;

public sealed record MissingWordOrExpressionClosedQuery(int AmountOfSentences)
    : ExerciseQueryBase, IQuery<ClosedAnswerExerciseResponseMissingWordOrExpression>;
    
public sealed class MissingWordOrExpressionClosedQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService,
    IEventDispatcher eventDispatcher)
    : IQueryHandler<MissingWordOrExpressionClosedQuery, ClosedAnswerExerciseResponseMissingWordOrExpression>
{
    public async Task<ClosedAnswerExerciseResponseMissingWordOrExpression> HandleAsync(MissingWordOrExpressionClosedQuery query)
    {
        var queryAsString = objectSamplerService.GetStringValues(query);
        var suspiciousPromptResponse = await openAiExerciseService.ValidateAvoidingOriginTopic(queryAsString);
        if (suspiciousPromptResponse.IsSuspicious)
        {
            await eventDispatcher.PublishAsync(new SuspiciousPromptInjected(suspiciousPromptResponse));
            throw new PromptInjectionException(suspiciousPromptResponse.Reasons);
        }
        
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(MissingWordOrExpressionClosed));

        var prompt =
            $"1. This is closed answer - missing word or expression exercise. This means that you need to generate {query.AmountOfSentences} sentences in which to cut out a word or expression. Replace word or expression with \"___\". Then generate 3 or 4 answers (one answer must be a cut word or expression from the original sentence), remember that only one of the answers must be correct.";
        
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<MissingWordOrExpressionClosed>(response);

        var result = new ClosedAnswerExerciseResponseMissingWordOrExpression()
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
        
        await eventDispatcher.PublishAsync(new ClosedAnswerExerciseResponseMissingWordOrExpressionGenerated(result));
        return result;
    }
}


