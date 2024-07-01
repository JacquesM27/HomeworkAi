using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.ClosedAnswer;

public sealed record ParaphrasingClosedQuery(int AmountOfSentences)
    : ExerciseQueryBase, IQuery<ClosedAnswerExerciseResponse<ParaphrasingClosed>>;

public sealed class ParaphrasingClosedQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService)
    : IQueryHandler<ParaphrasingClosedQuery, ClosedAnswerExerciseResponse<ParaphrasingClosed>>
{
    public async Task<ClosedAnswerExerciseResponse<ParaphrasingClosed>> HandleAsync(ParaphrasingClosedQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(ParaphrasingClosed));

        var prompt =
            $"1. This is closed answer - paraphrasing exercise. This means that you need to generate {query.AmountOfSentences} sentences in {query.TargetLanguage} and 3 to 4 paraphrases but only 1 can be correct.";
        
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        //TODO: if deserialization ends with exception add json fixing method
        var exercise = deserializerService.Deserialize<ParaphrasingClosed>(response);

        var result = new ClosedAnswerExerciseResponse<ParaphrasingClosed>()
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
        
        //TODO: add event/rabbit with exercise.
        return result;
    }
}


    
