using HomeworkAi.Core.DTO.Exercises;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace HomeworkAi.Core.Services.OpenAi;

public class OpenAiService(
    IOpenAIAPI openAiApi, 
    IPromptFormatter promptFormatter,
    IExerciseFormatService formatService
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

    //TODO: add this method
    public async Task<ExerciseResponse> ExercisePromptSentence(ExercisePrompt exercisePrompt)
    {

        _exerciseChat ??= openAiApi.Chat.CreateConversation(); 
        //var chat = openAiApi.Chat.CreateConversation();
        var startMessage =
            promptFormatter.FormatStartingSystemMessage(exercisePrompt.MotherLanguage.Value, exercisePrompt.TargetLanguage.Value);
        _exerciseChat.AppendSystemMessage(startMessage);
        var exerciseJsonFormat = formatService.FormatType(exercisePrompt.ExerciseType);
        _exerciseChat.AppendUserInput(exercisePrompt.ToPrompt(exerciseJsonFormat));
        var result = await _exerciseChat.GetResponseFromChatbotAsync();
        //TODO: only for test
        return new ExerciseResponse();
    }

    public async Task<bool> IsUserPromptAvoidOriginTopic(string topic)
    {
        _promptSecurityChat ??= openAiApi.Chat.CreateConversation();
        //TODO: only for test
        return true;
    }
}