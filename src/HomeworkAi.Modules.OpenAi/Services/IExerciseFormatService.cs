using HomeworkAi.Modules.Contracts;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Core.Services;

public interface IExerciseFormatService
{
    public string FormatType(string exerciseType);
    public Exercise DeserializeExercise(string json, string exerciseType);
    public SuspiciousPrompt DeserializeSuspiciousPrompt(string json);
}