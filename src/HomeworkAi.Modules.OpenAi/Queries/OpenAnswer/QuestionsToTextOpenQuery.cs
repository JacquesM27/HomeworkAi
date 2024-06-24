using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;

public sealed record QuestionsToTextOpenQuery(int AmountOfSentences, bool TextInMotherLanguage)
    : ExerciseQueryBase, IQuery<OpenAnswerExerciseResponse<QuestionsToTextOpen>>;

public sealed class QuestionsToTextQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService)
    : IQueryHandler<QuestionsToTextOpenQuery, OpenAnswerExerciseResponse<QuestionsToTextOpen>>
{
    public async Task<OpenAnswerExerciseResponse<QuestionsToTextOpen>> HandleAsync(QuestionsToTextOpenQuery query)
    {
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(QuestionsToTextOpen));
        
        var prompt = $"1. This is open answer - questions to text exercise. This means that need to generate a text in {(query.TextInMotherLanguage ? query.MotherLanguage : query.TargetLanguage)} language (about 10 sentences) according to the following requirements and {query.AmountOfSentences} questions in {query.TargetLanguage} language for this text. The questions are to be about things in the text or derived from the context of the text. ";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<QuestionsToTextOpen>(response);
        exercise.TextInMotherLanguage = query.TextInMotherLanguage;

        var result = new OpenAnswerExerciseResponse<QuestionsToTextOpen>()
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

