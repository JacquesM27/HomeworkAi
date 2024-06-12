using HomeworkAi.Core.DTO.Exercises;
using OpenAI_API.Completions;

namespace HomeworkAi.OpenAi;

public interface IOpenAiService
{
    Task<CompletionResult> CompleteSentence(string text);
    Task<string> GetChatConversations(string text);
    Task<ExerciseResponse> ExercisePromptSentence(ExercisePrompt exercisePrompt);
    Task<bool> IsUserPromptAvoidOriginTopic(string topic);
}