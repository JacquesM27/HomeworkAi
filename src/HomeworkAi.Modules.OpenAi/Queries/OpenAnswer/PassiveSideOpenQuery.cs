using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;

public sealed record PassiveSideOpenQuery(int AmountOfSentences, bool TranslateFromMotherLanguage) 
    : ExerciseQueryBase, IQuery<OpenAnswerExerciseResponse<PassiveSideOpen>>;

public sealed class PassiveSideOpenQueryHandler(IPromptFormatter promptFormatter, IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService, IDeserializerService deserializerService)
    : IQueryHandler<PassiveSideOpenQuery, OpenAnswerExerciseResponse<PassiveSideOpen>>
{
    public async Task<OpenAnswerExerciseResponse<PassiveSideOpen>> HandleAsync(PassiveSideOpenQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(PassiveSideOpen));
        
        var prompt = $"1. This is open answer - passive side exercise. This means that need to generate {query.AmountOfSentences} sentences in {(query.TranslateFromMotherLanguage ? query.MotherLanguage : query.TargetLanguage)} in the passive side so that the student can translate them into {(query.TranslateFromMotherLanguage ? query.TargetLanguage : query.MotherLanguage)} independently.";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<PassiveSideOpen>(response);

        var result = new OpenAnswerExerciseResponse<PassiveSideOpen>()
        {
            Exercise = exercise,
            ExerciseHeaderInMotherLanguage = query.ExerciseHeaderInMotherLanguage,
            MotherLanguage = query.MotherLanguage,
            TargetLanguage = query.TargetLanguage,
            TargetLanguageLevel = query.TargetLanguageLevel,
            TopicsOfSentences = query.TopicsOfSentences,
            GrammarSection = query.GrammarSection,
            TranslateFromMotherLanguage = query.TranslateFromMotherLanguage,
            AmountOfSentences = query.AmountOfSentences
        };
        
        //TODO: add event/rabbit with exercise.
        return result;
    }
}

