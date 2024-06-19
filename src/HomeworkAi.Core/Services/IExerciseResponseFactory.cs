using HomeworkAi.Core.DTO.Exercises;

namespace HomeworkAi.Core.Services;

public interface IExerciseResponseFactory
{
    ExerciseResponse CreateResponse(Exercise exercise, ExercisePrompt prompt);
}