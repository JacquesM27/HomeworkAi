using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Modules.Contracts.Events.Exercises.ClosedAnswer;

public sealed record ClosedAnswerExerciseGenerated<TExercise>(ClosedAnswerExerciseResponse<TExercise> Exercise) 
    : IEvent where TExercise : ClosedAnswerExercise;