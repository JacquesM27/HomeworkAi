using HomeworkAi.Modules.OpenAi.Exercises;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Modules.OpenAi.Services;

public interface IExerciseResponseFactory
{
    ExerciseResponseOld CreateResponse(Exercise exercise, ExercisePromptOld promptOld);
}