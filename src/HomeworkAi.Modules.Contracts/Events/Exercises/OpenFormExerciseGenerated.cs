using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Modules.Contracts.Events.Exercises;

public sealed record OpenFormExerciseGenerated<TExercise>(OpenFormExerciseResponse<TExercise> Exercise)
    : IEvent where TExercise : OpenFormExercise;