using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.ClosedAnswer;

public sealed record WordMeaningClosedQuery(int AmountOfSentences, bool DescriptionInMotherLanguage)
    : ExerciseQueryBase, IQuery<ClosedAnswerExerciseResponse<WordMeaningClosed>>;

public sealed class WordMeaningClosedQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService)
    : IQueryHandler<WordMeaningClosedQuery, ClosedAnswerExerciseResponse<WordMeaningClosed>>
{
    public async Task<ClosedAnswerExerciseResponse<WordMeaningClosed>> HandleAsync(WordMeaningClosedQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(WordMeaningClosed));

        var prompt =
            $"1. This is closed answer - word meaning exercise. This means that you need to generate {query.AmountOfSentences} words in {query.TargetLanguage} and 3-4 meanings (meaning is short description) for them in {(query.DescriptionInMotherLanguage ? query.MotherLanguage : query.TargetLanguage)} (1 meaning per MeaningAnswer object - it implies that in ShortDescription file can be only one meaning.). Pay attention to languages, words in {query.TargetLanguage} and meanings in {(query.DescriptionInMotherLanguage ? query.MotherLanguage : query.TargetLanguage)}. Remember - only one meaning can be correct.";

        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;

        var response =
            await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<WordMeaningClosed>(response);

        var result = new ClosedAnswerExerciseResponse<WordMeaningClosed>()
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


