using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.ClosedAnswer;

public sealed record WordMeaningQuery(int AmountOfSentences, bool DescriptionInMotherLanguage)
    : ExerciseQueryBase, IQuery<ClosedAnswerExerciseResponse<WordMeaning>>;

public sealed class WordMeaningQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService)
    : IQueryHandler<WordMeaningQuery, ClosedAnswerExerciseResponse<WordMeaning>>
{
    public async Task<ClosedAnswerExerciseResponse<WordMeaning>> HandleAsync(WordMeaningQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(WordMeaning));

        var prompt =
            $"1. This is closed answer - word meaning exercise. This means that you need to generate words in {query.TargetLanguage} and 3-4 meanings for them in {(query.DescriptionInMotherLanguage ? query.MotherLanguage : query.TargetLanguage)}. Remember - only one meaning can be correct.";

        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;

        var response =
            await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<WordMeaning>(response);

        var result = new ClosedAnswerExerciseResponse<WordMeaning>()
        {
            Exercise = exercise,
            ExerciseHeaderInMotherLanguage = query.ExerciseHeaderInMotherLanguage,
            MotherLanguage = query.MotherLanguage,
            TargetLanguage = query.TargetLanguage,
            TargetLanguageLevel = query.TargetLanguageLevel,
            TopicsOfSentences = query.TopicsOfSentences,
            GrammarSection = query.GrammarSection,
            AmountOfSentences = query.AmountOfSentences,
            DescriptionInMotherLanguage = query.DescriptionInMotherLanguage
        };

        //TODO: add event/rabbit with exercise.
        return result;
    }
}


