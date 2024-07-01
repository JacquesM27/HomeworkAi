using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.ClosedAnswer;

public sealed record MissingPhrasalVerbClosedQuery(int AmountOfSentences)
    : ExerciseQueryBase, IQuery<ClosedAnswerExerciseResponse<MissingPhrasalVerbClosed>>;
    
public sealed class MissingPhrasalVerbClosedQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService)
    : IQueryHandler<MissingPhrasalVerbClosedQuery, ClosedAnswerExerciseResponse<MissingPhrasalVerbClosed>>
{
    public async Task<ClosedAnswerExerciseResponse<MissingPhrasalVerbClosed>> HandleAsync(MissingPhrasalVerbClosedQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(MissingPhrasalVerbClosed));

        var prompt =
            $"1. This is closed answer - missing phrasal verb exercise. This means that you need to generate {query.AmountOfSentences} sentences with phrasal verbs. Replace phrasal verb with \"___\". Then generate 3 or 4 answers (one answer must be a cut phrasal verb from the original sentence), remember that only one of the answers must be correct. Additional information: the verb in the wrong answers must be the same or similar to the correct answer.";
        
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<MissingPhrasalVerbClosed>(response);

        var result = new ClosedAnswerExerciseResponse<MissingPhrasalVerbClosed>()
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


