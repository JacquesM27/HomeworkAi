using HomeworkAi.Core.DTO;
using HomeworkAi.Core.DTO.Exercises;

namespace HomeworkAi.Core.Services;

public interface IExerciseFormatService
{
    public string FormatType(string exerciseType);
    public Exercise DeserializeExercise(string json, string exerciseType);
    public SuspiciousPrompt DeserializeSuspiciousPrompt(string json);
}