using HomeworkAi.Core.Commands;

namespace HomeworkAi.Core.Services;

public interface IPromptFormatter
{
    string FormatExercisePrompt(ExerciseCommandBase baseData);
    string FormatStartingSystemMessage(string motherLanguage, string targetLanguage);
    string FormatValidationSystemMessage();
    //TODO: add verification of the student's answers
}