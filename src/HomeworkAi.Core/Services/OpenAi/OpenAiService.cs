using HomeworkAi.Core.DTO.Exercises;
using HomeworkAi.Core.Exceptions;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace HomeworkAi.Core.Services.OpenAi;

public class OpenAiService(
    IOpenAIAPI openAiApi, 
    IPromptFormatter promptFormatter,
    IExerciseFormatService formatService,
    IObjectSamplerService objectSamplerService,
    IExerciseResponseFactory responseFactory
    ) : IOpenAiService
{
    private static Conversation? _exerciseChat;
    private static Conversation? _promptSecurityChat;
    
    public async Task<CompletionResult> CompleteSentence(string text)
    {
        var completionRequest = new CompletionRequest();
        completionRequest.Model = Model.DefaultModel;
        //completionRequest.MaxTokens = 100;
        completionRequest.Prompt = text;
        var result = await openAiApi.Completions.CreateCompletionAsync(completionRequest);
        return result;
    }

    public async Task<string> GetChatConversations(string text)
    {
        var chat = openAiApi.Chat.CreateConversation();
        chat.AppendUserInput(text);
        var response = await chat.GetResponseFromChatbotAsync();
        return response;
    }

    public async Task<ExerciseResponse> ExercisePromptSentence(ExercisePrompt exercisePrompt)
    {
        if (await IsUserPromptAvoidOriginTopic(exercisePrompt))
            throw new PromptInjectionException();

        _exerciseChat ??= openAiApi.Chat.CreateConversation(); 
        var startMessage =
            promptFormatter.FormatStartingSystemMessage(exercisePrompt.MotherLanguage.Value, exercisePrompt.TargetLanguage.Value);
        _exerciseChat.AppendSystemMessage(startMessage);
        var exerciseJsonFormat = formatService.FormatType(exercisePrompt.ExerciseType);
        _exerciseChat.AppendUserInput(exercisePrompt.ToPrompt(exerciseJsonFormat));
        var result = await _exerciseChat.GetResponseFromChatbotAsync();
        var deserialized = formatService.DeserializeExercise(result, exercisePrompt.ExerciseType);
        var response = responseFactory.CreateResponse(deserialized, exercisePrompt);
        return response;
    }

    public async Task<bool> IsUserPromptAvoidOriginTopic(ExercisePrompt exercisePrompt)
    {
        var startMessage = promptFormatter.FormatValidationSystemMessage();
        _promptSecurityChat ??= openAiApi.Chat.CreateConversation();
        _promptSecurityChat.AppendSystemMessage(startMessage);
        var exercise = $"\nExercise prompt: \"{objectSamplerService.GetStringValues(exercisePrompt)}\"";
        _promptSecurityChat.AppendUserInput(exercise);
        var result = await _promptSecurityChat.GetResponseFromChatbotAsync();
        var deserialized = formatService.DeserializeSuspiciousPrompt(result);
        return deserialized.IsSuspicious;
    }
}