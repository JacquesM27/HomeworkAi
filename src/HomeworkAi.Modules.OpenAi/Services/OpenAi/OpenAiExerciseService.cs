using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.OpenAi.Exercises;
using HomeworkAi.Modules.Contracts;
using HomeworkAi.Modules.Contracts.Exercises;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace HomeworkAi.Modules.OpenAi.Services.OpenAi;

public class OpenAiExerciseService(
    IOpenAIAPI openAiApi, 
    IPromptFormatter promptFormatter,
    IDeserializerService formatService,
    IObjectSamplerService objectSamplerService,
    IExerciseResponseFactory responseFactory
    ) : IOpenAiExerciseService
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

    public async Task<ExerciseResponseOld> PromptForExercise(ExercisePromptOld exercisePromptOld)
    {
        if (await IsUserPromptAvoidOriginTopic(exercisePromptOld))
            throw new PromptInjectionException();

        _exerciseChat ??= openAiApi.Chat.CreateConversation(); 
        var startMessage =
            promptFormatter.FormatStartingSystemMessage(exercisePromptOld.MotherLanguage.Value, exercisePromptOld.TargetLanguage.Value);
        _exerciseChat.AppendSystemMessage(startMessage);
        var exerciseJsonFormat = formatService.FormatType(exercisePromptOld.ExerciseType);
        _exerciseChat.AppendUserInput(exercisePromptOld.ToPrompt(exerciseJsonFormat));
        var result = await _exerciseChat.GetResponseFromChatbotAsync();
        var deserialized = formatService.DeserializeExercise(result, exercisePromptOld.ExerciseType);
        var response = responseFactory.CreateResponse(deserialized, exercisePromptOld);
        return response;
    }

    public Task<string> PromptForExercise(string prompt, string motherLanguage, string targetLanguage)
    {
        if (_exerciseChat is null)
        {
            _exerciseChat = openAiApi.Chat.CreateConversation();
            var startMessage =
                promptFormatter.FormatStartingSystemMessage(motherLanguage, targetLanguage);
            _exerciseChat.AppendSystemMessage(startMessage);
        }
        
        _exerciseChat.AppendUserInput(prompt);
        
        return _exerciseChat.GetResponseFromChatbotAsync();
    }

    public async Task<SuspiciousPrompt> ValidateAvoidingOriginTopic(string prompt)
    {
        if (_promptSecurityChat is null)
        {
            _promptSecurityChat = openAiApi.Chat.CreateConversation();
            var startMessage = promptFormatter.FormatValidationSystemMessage();
            _promptSecurityChat.AppendSystemMessage(startMessage);
        }
        _promptSecurityChat.AppendUserInput(prompt);
        var result = await _promptSecurityChat.GetResponseFromChatbotAsync();
        var deserialized = formatService.DeserializeSuspiciousPrompt(result);
        return deserialized;
    }

    public async Task<bool> IsUserPromptAvoidOriginTopic(ExercisePromptOld exercisePromptOld)
    {
        var startMessage = promptFormatter.FormatValidationSystemMessage();
        _promptSecurityChat ??= openAiApi.Chat.CreateConversation();
        _promptSecurityChat.AppendSystemMessage(startMessage);
        var exercise = $"\nExercise prompt: \"{objectSamplerService.GetStringValues(exercisePromptOld)}\"";
        _promptSecurityChat.AppendUserInput(exercise);
        var result = await _promptSecurityChat.GetResponseFromChatbotAsync();
        var deserialized = formatService.DeserializeSuspiciousPrompt(result);
        return deserialized.IsSuspicious;
    }
}