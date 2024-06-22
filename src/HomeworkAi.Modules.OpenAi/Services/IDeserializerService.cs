using HomeworkAi.Modules.Contracts;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Modules.OpenAi.Services;

public interface IDeserializerService
{
    public string FormatType(string exerciseType);
    public Exercise DeserializeExercise(string json, string exerciseType);
    public SuspiciousPrompt DeserializeSuspiciousPrompt(string json);
    public T Deserialize<T>(string json);
}