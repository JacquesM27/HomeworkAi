using HomeworkAi.Core.Exercises;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Core.Services;

public interface IExerciseResponseFactory
{
    ExerciseResponseOld CreateResponse(Exercise exercise, ExercisePromptOld promptOld);
}