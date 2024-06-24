using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;

public sealed record ConditionalOpenQuery(int AmountOfSentences, bool TranslateFromMotherLanguage, bool ZeroConditional,
    bool FirstConditional, bool SecondConditional, bool ThirdConditional) 
    : ExerciseQueryBase, IQuery<OpenAnswerExerciseResponse<ConditionalOpen>>;
    
public sealed class ConditionalOpenQueryHandler(IPromptFormatter promptFormatter, IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService, IDeserializerService deserializerService)
    : IQueryHandler<ConditionalOpenQuery, OpenAnswerExerciseResponse<ConditionalOpen>>
{
    public async Task<OpenAnswerExerciseResponse<ConditionalOpen>> HandleAsync(ConditionalOpenQuery query)
    {
        var roundedAmountOfSentences = RoundedAmountOfSentences(query);

        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(ConditionalOpen));
        
        var prompt = $"1. This is open answer - conditional exercise. This means that need to generate {roundedAmountOfSentences} sentences each in {(query.TranslateFromMotherLanguage ? query.MotherLanguage : query.TargetLanguage)} so that they are translatable by the student into {(query.TranslateFromMotherLanguage ? query.TargetLanguage : query.MotherLanguage)}. Sentences must be in the indicated conditional modes - {(query.ZeroConditional ? "zero, " : "")}{(query.FirstConditional ? "first, " : "")}{(query.SecondConditional ? "second, " : "")}{(query.ThirdConditional ? "third": "")} - in JSON you have list for each mode, complete only those lists that were mentioned in the previous sentence.";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<ConditionalOpen>(response);

        var result = new OpenAnswerExerciseResponse<ConditionalOpen>()
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

    private static int RoundedAmountOfSentences(ConditionalOpenQuery query)
    {
        bool[] conditions = [query.ZeroConditional, query.FirstConditional, query.SecondConditional, query.ThirdConditional];
        var conditionalDenominator = conditions.Count(c => c);
        var amountOfSentences = (double)query.AmountOfSentences / conditionalDenominator;
        var roundedAmountOfSentences = (int)Math.Ceiling(amountOfSentences);
        return roundedAmountOfSentences;
    }
}