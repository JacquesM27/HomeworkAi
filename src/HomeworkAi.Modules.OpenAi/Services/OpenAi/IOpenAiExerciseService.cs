using HomeworkAi.Modules.Contracts;

namespace HomeworkAi.Modules.OpenAi.Services.OpenAi;

public interface IOpenAiExerciseService
{
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
    
}