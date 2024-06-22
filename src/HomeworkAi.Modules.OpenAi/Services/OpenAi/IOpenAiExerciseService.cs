using HomeworkAi.Modules.OpenAi.Exercises;
using HomeworkAi.Modules.Contracts;
using HomeworkAi.Modules.Contracts.Exercises;
using OpenAI_API.Completions;

namespace HomeworkAi.Modules.OpenAi.Services.OpenAi;

public interface IOpenAiExerciseService
{
    //TODO: remove
    Task<CompletionResult> CompleteSentence(string text);
    
    //TODO: remove
    Task<string> GetChatConversations(string text);
    
    //TODO: remove
    Task<ExerciseResponseOld> PromptForExercise(ExercisePromptOld exercisePromptOld);

    /// <summary>
    /// It does not validate prompt.
    /// </summary>
    /// <param name="prompt">Formatted prompt with exercise details.</param>
    /// <param name="motherLanguage">Student's national language.</param>
    /// <param name="targetLanguage">Target language of the task.</param>
    /// <returns>json with exercise</returns>
    Task<string> PromptForExercise(string prompt, string motherLanguage, string targetLanguage);

    /// <summary>
    /// Validates attempt to inject invalid data.
    /// </summary>
    /// <param name="prompt">Data to validate.</param>
    /// <returns>Object with bool flag and reasons of suspicious (if any).</returns>
    Task<SuspiciousPrompt> ValidateAvoidingOriginTopic(string prompt);
    
    //TODO: remove
    Task<bool> IsUserPromptAvoidOriginTopic(ExercisePromptOld exercisePromptOld);
}