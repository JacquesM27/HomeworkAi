using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenForm;

public sealed record MailQuery(int MinimumNumberOfWords) : ExerciseQueryBase, IQuery<OpenFormExerciseResponse<Mail>>;

internal sealed class MailQueryHandler(IPromptFormatter promptFormatter, IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService, IDeserializerService deserializerService)
    : IQueryHandler<MailQuery, OpenFormExerciseResponse<Mail>>
{
    public async Task<OpenFormExerciseResponse<Mail>> HandleAsync(MailQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(Mail));

        var prompt = "1. This is open form - mail exercise. This means that you need to generate a short description of the email to be written by the student. Add information on who the email should be to.";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"12. In instruction field include information about the minimum number of words in email - {query.MinimumNumberOfWords}. It's important.\n";
        prompt += $"""
                   13. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<Mail>(response);

        var result = new OpenFormExerciseResponse<Mail>()
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