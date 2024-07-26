using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Events.SuspiciousPrompts;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;

public sealed record MissingPhrasalVerbOpenQuery(int AmountOfSentences) 
    : ExerciseQueryBase, IQuery<OpenAnswerExerciseResponseMissingPhrasalVerb>;

public sealed class MissingPhrasalVerbOpenQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService, IDeserializerService deserializerService,
    IEventDispatcher eventDispatcher)
    : IQueryHandler<MissingPhrasalVerbOpenQuery, OpenAnswerExerciseResponseMissingPhrasalVerb>
{
    public async Task<OpenAnswerExerciseResponseMissingPhrasalVerb> HandleAsync(MissingPhrasalVerbOpenQuery query)
    {
        var queryAsString = objectSamplerService.GetStringValues(query);
        var suspiciousPromptResponse = await openAiExerciseService.ValidateAvoidingOriginTopic(queryAsString);
        if (suspiciousPromptResponse.IsSuspicious)
        {
            await eventDispatcher.PublishAsync(new SuspiciousPromptInjected(suspiciousPromptResponse));
            throw new PromptInjectionException(suspiciousPromptResponse.Reasons);
        }
        
        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(MissingPhrasalVerbOpen));
        
        var prompt = $"1. This is open answer - missing phrasal verbs exercise. This means that need to generate {query.AmountOfSentences} sentences with phrasal verbs. Record the correct phrasal verb in the CorrectPhrasalVerb field. In addition, in the SentenceWithUnderscoreInsteadOfPhrasalVerb field, write a sentence in which you replace phrasal verbs with ___. ";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;
        
        var response = await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<MissingPhrasalVerbOpen>(response);

        var result = new OpenAnswerExerciseResponseMissingPhrasalVerb()
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
        
        await eventDispatcher.PublishAsync(new OpenAnswerExerciseResponseMissingPhrasalVerbGenerated(result));
        return result;
    }
}


