using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;

public sealed record IrregularVerbsQuery(int AmountOfSentences, bool ShowMotherLanguage, bool ShowFirstForm)
    : ExerciseQueryBase, IQuery<OpenAnswerExerciseResponse<IrregularVerbs>>;
    
public sealed class IrregularVerbsQueryHandler(IPromptFormatter promptFormatter, IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService, IDeserializerService deserializerService)
    : IQueryHandler<IrregularVerbsQuery, OpenAnswerExerciseResponse<IrregularVerbs>>
{
    public async Task<OpenAnswerExerciseResponse<IrregularVerbs>> HandleAsync(IrregularVerbsQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(IrregularVerbs));
        
        var prompt = $"1. This is open answer - irregular verbs exercise. This means that need to generate {query.AmountOfSentences} irregular verbs. Fill all forms in target language ({query.TargetLanguage}) and add translation in mother language ({query.MotherLanguage}). Ignore fields ShowMotherLanguage and ShowFirstForm do not fill them in JSON.";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<IrregularVerbs>(response);

        var result = new OpenAnswerExerciseResponse<IrregularVerbs>()
        {
            Exercise = exercise,
            ExerciseHeaderInMotherLanguage = query.ExerciseHeaderInMotherLanguage,
            MotherLanguage = query.MotherLanguage,
            TargetLanguage = query.TargetLanguage,
            TargetLanguageLevel = query.TargetLanguageLevel,
            TopicsOfSentences = query.TopicsOfSentences,
            GrammarSection = query.GrammarSection,
            AmountOfSentences = query.AmountOfSentences,
            ShowFirstForm = query.ShowFirstForm,
            ShowMotherLanguage = query.ShowMotherLanguage
        };
        
        //TODO: add event/rabbit with exercise.
        return result;
    }
}