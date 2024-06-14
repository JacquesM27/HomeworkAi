using HomeworkAi.Core.DTO.Exercises;

namespace HomeworkAi.Core.Services;

public interface IPromptFormatter
{
    string FormatPromptWithExercise(ExercisePrompt prompt);
    string FormatStartingSystemMessage(string motherLanguage, string targetLanguage);
    string FormatValidationSystemMessage();
    //TODO: add verification of the student's answers
}