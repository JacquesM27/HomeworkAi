using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.ClosedAnswer;

public sealed record PassiveSideClosedQuery(int AmountOfSentences)
    : ExerciseQueryBase, IQuery<ClosedAnswerExerciseResponse<PassiveSideClosed>>;


public sealed class PassiveSideClosedQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService,
    IEventDispatcher eventDispatcher)
    : IQueryHandler<PassiveSideClosedQuery, ClosedAnswerExerciseResponse<PassiveSideClosed>>
{
    public async Task<ClosedAnswerExerciseResponse<PassiveSideClosed>> HandleAsync(PassiveSideClosedQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(PassiveSideClosed));

        var prompt =
            $"1. This is closed answer - passive side exercise. This means that you need to generate {query.AmountOfSentences} sentences in {query.TargetLanguage} in the passive side and answers to them from 3 to 4 according to the json format provided. Only one answer must be grammatically correct and the others are to be incorrect (have small grammatical errors). ";
        
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<PassiveSideClosed>(response);

        var result = new ClosedAnswerExerciseResponse<PassiveSideClosed>()
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
        
        await eventDispatcher.PublishAsync(new ClosedAnswerExerciseGenerated<PassiveSideClosed>(result));
        return result;
    }
}


    
