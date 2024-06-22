using HomeworkAi.Modules.OpenAi.Commands;

namespace HomeworkAi.Modules.OpenAi.Services;

public interface IPromptFormatter
{
    string FormatExerciseBaseData(ExerciseQueryBase baseData);
    string FormatStartingSystemMessage(string motherLanguage, string targetLanguage);
    string FormatValidationSystemMessage();
    //TODO: add verification of the student's answers
}