using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Events.SuspiciousPrompts;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;

namespace HomeworkAi.Modules.OpenAi.Queries.OpenForm;

public sealed record MailQuery(int MinimumNumberOfWords) 
    : ExerciseQueryBase, IQuery<OpenFormExerciseResponseMail>;

internal sealed class MailQueryHandler(
    IPromptFormatter promptFormatter, 
    IObjectSamplerService objectSamplerService,
    IOpenAiExerciseService openAiExerciseService, 
    IDeserializerService deserializerService,
    IEventDispatcher eventDispatcher)
    : IQueryHandler<MailQuery, OpenFormExerciseResponseMail>
{
    public async Task<OpenFormExerciseResponseMail> HandleAsync(MailQuery query)
    {
        var queryAsString = objectSamplerService.GetStringValues(query);
        var suspiciousPromptResponse = await openAiExerciseService.ValidateAvoidingOriginTopic(queryAsString);
        if (suspiciousPromptResponse.IsSuspicious)
        {
            await eventDispatcher.PublishAsync(new SuspiciousPromptInjected(suspiciousPromptResponse));
            throw new PromptInjectionException(suspiciousPromptResponse.Reasons);
        }
        
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

        var result = new OpenFormExerciseResponseMail()
        {
            Exercise = exercise,
            ExerciseHeaderInMotherLanguage = query.ExerciseHeaderInMotherLanguage,
            MotherLanguage = query.MotherLanguage,
            TargetLanguage = query.TargetLanguage,
            TargetLanguageLevel = query.TargetLanguageLevel,
            TopicsOfSentences = query.TopicsOfSentences,
            GrammarSection = query.GrammarSection
        };
        
        await eventDispatcher.PublishAsync(new OpenFormExerciseResponseMailGenerated(result));
        return result;
    }
}