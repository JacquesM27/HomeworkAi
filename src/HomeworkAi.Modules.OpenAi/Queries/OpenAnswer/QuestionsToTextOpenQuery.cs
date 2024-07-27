using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Events.SuspiciousPrompts;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;

public sealed record QuestionsToTextOpenQuery(int AmountOfSentences, bool QuestionsInMotherLanguage)
    : ExerciseQueryBase, IQuery<OpenAnswerExerciseResponseQuestionsToText>;

public sealed class QuestionsToTextOpenQueryHandler(
    IPromptFormatter promptFormatter,
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService,
    IDeserializerService deserializerService,
    IEventDispatcher eventDispatcher)
    : IQueryHandler<QuestionsToTextOpenQuery, OpenAnswerExerciseResponseQuestionsToText>
{
    public async Task<OpenAnswerExerciseResponseQuestionsToText> HandleAsync(QuestionsToTextOpenQuery query)
    {
        var queryAsString = objectSamplerService.GetStringValues(query);
        var suspiciousPromptResponse = await openAiExerciseService.ValidateAvoidingOriginTopic(queryAsString);
        if (suspiciousPromptResponse.IsSuspicious)
        {
            await eventDispatcher.PublishAsync(new SuspiciousPromptInjected(suspiciousPromptResponse));
            throw new PromptInjectionException(suspiciousPromptResponse.Reasons);
        }

        var exerciseJsonFormat = objectSamplerService.GetSampleJson(typeof(QuestionsToTextOpen));

        var prompt =
            $"1. This is open answer - questions to text exercise. Your task is to generate a text (10 sentences - do not enumerate them) in {query.TargetLanguage} and questions to this text in {(query.QuestionsInMotherLanguage ? query.MotherLanguage : query.TargetLanguage)}. ";
        prompt += promptFormatter.FormatExerciseBaseData(query);
        prompt += $"""
                   12. Your responses should be structured in JSON format as follows:
                   {exerciseJsonFormat}
                   """;

        var response =
            await openAiExerciseService.PromptForExercise(prompt, query.MotherLanguage, query.TargetLanguage);

        var exercise = deserializerService.Deserialize<QuestionsToTextOpen>(response);

        var result = new OpenAnswerExerciseResponseQuestionsToText()
        {
            Exercise = exercise,
            ExerciseHeaderInMotherLanguage = query.ExerciseHeaderInMotherLanguage,
            MotherLanguage = query.MotherLanguage,
            TargetLanguage = query.TargetLanguage,
            TargetLanguageLevel = query.TargetLanguageLevel,
            TopicsOfSentences = query.TopicsOfSentences,
            GrammarSection = query.GrammarSection,
            AmountOfSentences = query.AmountOfSentences,
            QuestionsInMotherLanguage = query.QuestionsInMotherLanguage
        };

        await eventDispatcher.PublishAsync(new OpenAnswerExerciseResponseQuestionsToTextGenerated(result));
        return result;
    }
}