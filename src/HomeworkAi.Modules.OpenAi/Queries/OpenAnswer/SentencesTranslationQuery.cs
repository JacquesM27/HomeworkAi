using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;

public sealed record SentencesTranslationQuery(int AmountOfSentences, bool TranslateFromMotherLanguage) : ExerciseQueryBase, IQuery<OpenAnswerExerciseResponse<SentencesTranslation>>;

internal sealed class SentencesTranslationQueryHandler(IPromptFormatter promptFormatter, IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService, IDeserializerService deserializerService)
    : IQueryHandler<SentencesTranslationQuery, OpenAnswerExerciseResponse<SentencesTranslation>>
{
    public async Task<OpenAnswerExerciseResponse<SentencesTranslation>> HandleAsync(SentencesTranslationQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(SentencesTranslation));
        
        var prompt = $"1. This is open answer - sentences translation exercise. This means that need to generate {query.AmountOfSentences} for the student to translate. Sentences must be in {(query.TranslateFromMotherLanguage ? query.MotherLanguage : query.TargetLanguage)} so that they are translatable by the student into {(query.TranslateFromMotherLanguage ? query.TargetLanguage : query.MotherLanguage)}.";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<SentencesTranslation>(response);

        var result = new OpenAnswerExerciseResponse<SentencesTranslation>()
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