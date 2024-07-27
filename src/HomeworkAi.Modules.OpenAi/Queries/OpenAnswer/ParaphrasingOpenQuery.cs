using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Events.SuspiciousPrompts;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;

public sealed record ParaphrasingOpenQuery(int AmountOfSentences)
    : ExerciseQueryBase, IQuery<OpenAnswerExerciseResponseParaphrasing>;

public sealed class ParaphrasingOpenQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService,
    IEventDispatcher eventDispatcher)
    : IQueryHandler<ParaphrasingOpenQuery, OpenAnswerExerciseResponseParaphrasing>
{
    public async Task<OpenAnswerExerciseResponseParaphrasing> HandleAsync(ParaphrasingOpenQuery query)
    {
        var queryAsString = objectSamplerService.GetStringValues(query);
        var suspiciousPromptResponse = await openAiExerciseService.ValidateAvoidingOriginTopic(queryAsString);
        if (suspiciousPromptResponse.IsSuspicious)
        {
            await eventDispatcher.PublishAsync(new SuspiciousPromptInjected(suspiciousPromptResponse));
            throw new PromptInjectionException(suspiciousPromptResponse.Reasons);
        }

        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(ParaphrasingOpen));

        var prompt =
            $"1. This is open answer - paraphrasing exercise. This means that need to generate {query.AmountOfSentences} sentences in {query.TargetLanguage} so that they can be paraphrased. Transformations involve transforming sentences, that is, expressing the same thought in a different way.";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;

        var response =
            await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<ParaphrasingOpen>(response);

        var result = new OpenAnswerExerciseResponseParaphrasing()
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

        await eventDispatcher.PublishAsync(new OpenAnswerExerciseResponseParaphrasingGenerated(result));
        return result;
    }
}