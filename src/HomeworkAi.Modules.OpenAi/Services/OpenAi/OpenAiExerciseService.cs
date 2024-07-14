using HomeworkAi.Modules.Contracts;
using OpenAI_API;
using OpenAI_API.Chat;

namespace HomeworkAi.Modules.OpenAi.Services.OpenAi;

public class OpenAiExerciseService(
    IOpenAIAPI openAiApi, 
    IPromptFormatter promptFormatter,
    IDeserializerService formatService
    ) : IOpenAiExerciseService
{
    private static Conversation? _exerciseChat;
    private static Conversation? _promptSecurityChat;
    
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
}