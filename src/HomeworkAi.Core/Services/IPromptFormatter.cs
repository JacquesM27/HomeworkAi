namespace HomeworkAi.Core.Services;

public interface IPromptFormatter
{
    string FormatStartingSystemMessage(string motherLanguage, string targetLanguage);
    string FormatValidationSystemMessage();
    //TODO: add verification of the student's answers
}