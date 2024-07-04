using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;

public sealed record ParaphrasingOpenQuery(int AmountOfSentences) : ExerciseQueryBase, IQuery<OpenAnswerExerciseResponse<ParaphrasingOpen>>;

public sealed class ParaphrasingOpenQueryHandler(IPromptFormatter promptFormatter, IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService, IDeserializerService deserializerService)
    : IQueryHandler<ParaphrasingOpenQuery, OpenAnswerExerciseResponse<ParaphrasingOpen>>
{
    public async Task<OpenAnswerExerciseResponse<ParaphrasingOpen>> HandleAsync(ParaphrasingOpenQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(ParaphrasingOpen));
        
        var prompt = $"1. This is open answer - paraphrasing exercise. This means that need to generate {query.AmountOfSentences} sentences in {query.TargetLanguage} so that they can be paraphrased. Transformations involve transforming sentences, that is, expressing the same thought in a different way.";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<ParaphrasingOpen>(response);

        var result = new OpenAnswerExerciseResponse<ParaphrasingOpen>()
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