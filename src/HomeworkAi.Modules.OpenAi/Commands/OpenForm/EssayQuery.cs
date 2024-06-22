using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Commands.OpenForm;

public sealed record EssayQuery(int MinimumNumberOfWords) : ExerciseQueryBase, IQuery<OpenFormExerciseResponse<Essay>>;

internal sealed class EssayQueryHandler(IPromptFormatter promptFormatter, IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService, IDeserializerService deserializerService)
    : IQueryHandler<EssayQuery, OpenFormExerciseResponse<Essay>>
{
    public async Task<OpenFormExerciseResponse<Essay>> HandleAsync(EssayQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(Essay));
        
        var prompt = "1. This is open form - essay exercise. This means that you need to generate a short essay topic to be written by the student.";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"12. In instruction field include information about the minimum number of words in essay - {query.MinimumNumberOfWords}. It's important.\n";
        prompt += $"""
                   13. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<Essay>(response);

        var result = new OpenFormExerciseResponse<Essay>()
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