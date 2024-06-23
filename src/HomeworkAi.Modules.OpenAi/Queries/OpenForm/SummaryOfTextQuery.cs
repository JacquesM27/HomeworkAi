using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenForm;

public sealed record SummaryOfTextQuery : ExerciseQueryBase, IQuery<OpenFormExerciseResponse<SummaryOfText>>;

internal sealed class SummaryOfTextQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService)
    : IQueryHandler<SummaryOfTextQuery, OpenFormExerciseResponse<SummaryOfText>>
{
    public async Task<OpenFormExerciseResponse<SummaryOfText>> HandleAsync(SummaryOfTextQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(SummaryOfText));
        
        var prompt = "1. This is open form - summary of text exercise. This means that you need to generate a story (about 10 sentences) to be summarized by the student.";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<SummaryOfText>(response);

        var result = new OpenFormExerciseResponse<SummaryOfText>()
        {
            Exercise = exercise,
            ExerciseHeaderInMotherLanguage = query.ExerciseHeaderInMotherLanguage,
            MotherLanguage = query.MotherLanguage,
            TargetLanguage = query.TargetLanguage,
            TargetLanguageLevel = query.TargetLanguageLevel,
            TopicsOfSentences = query.TopicsOfSentences,
            GrammarSection = query.GrammarSection
        };
        
        //TODO: add event/rabbit with exercise.
        return result;
    }
}