using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Modules.Contracts.Events.Exercises.ClosedAnswer;

public sealed record ConditionalClosedGenerated(ClosedAnswerExerciseResponse<ConditionalClosed> Exercise) : IEvent;