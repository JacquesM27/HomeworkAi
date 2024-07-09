using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Events.Exercises.ClosedAnswer;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.Events.Mappers;

namespace HomeworkAi.Modules.Persistence.Events.Handlers;

internal sealed class ClosedAnswerExerciseGeneratedHandler<TExercise>//(IClosedAnswerExerciseRepository repository)
    : IEventHandler<ClosedAnswerExerciseGenerated<TExercise>> where TExercise : ClosedAnswerExercise
{
    public Task HandleAsync(ClosedAnswerExerciseGenerated<TExercise> @event)
    {
        var mapped = @event.Exercise.Map();
        //return repository.AddAsync(mapped);
        return Task.CompletedTask;
    }
}