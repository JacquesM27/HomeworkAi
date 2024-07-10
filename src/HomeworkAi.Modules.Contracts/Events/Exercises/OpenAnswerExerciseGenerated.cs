using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Modules.Contracts.Events.Exercises;

public sealed record OpenAnswerExerciseGenerated<TExercise>(OpenAnswerExerciseResponse<TExercise> Exercise)
    : IEvent where TExercise : OpenAnswerExercise;