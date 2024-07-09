using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Events.Exercises.ClosedAnswer;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.ClosedAnswer;

public sealed record AnswerToQuestionClosedQuery(int AmountOfSentences)
    : ExerciseQueryBase, IQuery<ClosedAnswerExerciseResponse<AnswerToQuestionClosed>>;

public sealed class AnswerToQuestionClosedQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService,
    IEventDispatcher eventDispatcher)
    : IQueryHandler<AnswerToQuestionClosedQuery, ClosedAnswerExerciseResponse<AnswerToQuestionClosed>>
{
    public async Task<ClosedAnswerExerciseResponse<AnswerToQuestionClosed>> HandleAsync(AnswerToQuestionClosedQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(AnswerToQuestionClosed));

        var prompt =
            $"1. This is closed answer - answer to question exercise. This means that you need to generate {query.AmountOfSentences} questions and 3-4 answers to those questions, where only one answer is grammatically correct (other answers must have grammatical errors) . Questions and answers language is {query.TargetLanguage}.";
        
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<AnswerToQuestionClosed>(response);

        var result = new ClosedAnswerExerciseResponse<AnswerToQuestionClosed>()
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

        await eventDispatcher.PublishAsync(new ClosedAnswerExerciseGenerated<AnswerToQuestionClosed>(result));
        return result;
    }
}

