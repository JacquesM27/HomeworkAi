using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Events.SuspiciousPrompts;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.ClosedAnswer;

public sealed record QuestionsToTextClosedQuery(int AmountOfSentences, bool QuestionsInMotherLanguage)
    : ExerciseQueryBase, IQuery<ClosedAnswerExerciseResponse<QuestionsToTextClosed>>;
    
public sealed class QuestionsToTextClosedQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService,
    IEventDispatcher eventDispatcher)
    : IQueryHandler<QuestionsToTextClosedQuery, ClosedAnswerExerciseResponse<QuestionsToTextClosed>>
{
    public async Task<ClosedAnswerExerciseResponse<QuestionsToTextClosed>> HandleAsync(QuestionsToTextClosedQuery query)
    {
        var queryAsString = objectSamplerService.GetStringValues(query);
        var suspiciousPromptResponse = await openAiExerciseService.ValidateAvoidingOriginTopic(queryAsString);
        if (suspiciousPromptResponse.IsSuspicious)
        {
            await eventDispatcher.PublishAsync(new SuspiciousPromptInjected(suspiciousPromptResponse));
            throw new PromptInjectionException(suspiciousPromptResponse.Reasons);
        }
        
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(QuestionsToTextClosed));

        var prompt = $"1. This is closed answer - questions to text exercise. This means you need to generate a text according to the following requirements (5-8 sentences) and {query.AmountOfSentences} questions for this text. For questions you need to generate responses to them from 3 to 4 according to the json format provided." +
                 $"Only one answer must be grammatically correct and the others are to be incorrect (have small grammatical errors). Questions and answers for the text have to be in {(query.QuestionsInMotherLanguage ? query.MotherLanguage : query.TargetLanguage)}.";
        
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<QuestionsToTextClosed>(response);

        var result = new ClosedAnswerExerciseResponse<QuestionsToTextClosed>()
        {
            Exercise = exercise,
            ExerciseHeaderInMotherLanguage = query.ExerciseHeaderInMotherLanguage,
            MotherLanguage = query.MotherLanguage,
            TargetLanguage = query.TargetLanguage,
            TargetLanguageLevel = query.TargetLanguageLevel,
            TopicsOfSentences = query.TopicsOfSentences,
            GrammarSection = query.GrammarSection,
            AmountOfSentences = query.AmountOfSentences,
            QuestionsInMotherLanguage = query.QuestionsInMotherLanguage
        };
        
        await eventDispatcher.PublishAsync(new ClosedAnswerExerciseGenerated<QuestionsToTextClosed>(result));
        return result;
    }
}


    