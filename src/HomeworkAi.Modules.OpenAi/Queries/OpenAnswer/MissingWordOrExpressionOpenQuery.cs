using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Events.SuspiciousPrompts;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;

public sealed record MissingWordOrExpressionOpenQuery(int AmountOfSentences) 
    : ExerciseQueryBase, IQuery<OpenAnswerExerciseResponseMissingWordOrExpression>;
    
public sealed class MissingWordOrExpressionOpenQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService, IDeserializerService deserializerService,
    IEventDispatcher eventDispatcher)
    : IQueryHandler<MissingWordOrExpressionOpenQuery, OpenAnswerExerciseResponseMissingWordOrExpression>
{
    public async Task<OpenAnswerExerciseResponseMissingWordOrExpression> HandleAsync(MissingWordOrExpressionOpenQuery query)
    {
        var queryAsString = objectSamplerService.GetStringValues(query);
        var suspiciousPromptResponse = await openAiExerciseService.ValidateAvoidingOriginTopic(queryAsString);
        if (suspiciousPromptResponse.IsSuspicious)
        {
            await eventDispatcher.PublishAsync(new SuspiciousPromptInjected(suspiciousPromptResponse));
            throw new PromptInjectionException(suspiciousPromptResponse.Reasons);
        }
        
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(MissingWordOrExpressionOpen));
        
        var prompt = $"1. This is open answer - missing phrasal word or expression exercise. This means that need to generate {query.AmountOfSentences} sentences in which to cut out a word or expression. Record the correct word or phrase that will be cut in the CorrectWordOrExpression field. In addition, in the SentenceWithUnderscoreInsteadOfWordOrExpression field, write a sentence in which you will replace the word or phrase with ___. Pay attention to languages, sentences must be in {query.TargetLanguage}. ";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<MissingWordOrExpressionOpen>(response);

        var result = new OpenAnswerExerciseResponseMissingWordOrExpression()
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
        
        await eventDispatcher.PublishAsync(new OpenAnswerExerciseResponseMissingWordOrExpressionGenerated(result));
        return result;
    }
}