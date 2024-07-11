using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.DAL.Repositories;
using HomeworkAi.Modules.Persistence.Events.Mappers;

namespace HomeworkAi.Modules.Persistence.Events.Handlers;

internal sealed class OpenFormExerciseGeneratedHandler<TExercise>(IOpenFormExerciseRepository repository)
    : IEventHandler<OpenFormExerciseGenerated<TExercise>> where TExercise : OpenFormExercise
{
    public Task HandleAsync(OpenFormExerciseGenerated<TExercise> @event)
    {
        var mapped = @event.Exercise.Map();
        return repository.AddAsync(mapped);
    }
}