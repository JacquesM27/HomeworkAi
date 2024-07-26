using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.DAL.Repositories;
using HomeworkAi.Modules.Persistence.Events.Mappers;

namespace HomeworkAi.Modules.Persistence.Events.Handlers;

// internal sealed class OpenAnswerExerciseGeneratedHandler<TExercise>(IOpenAnswerExerciseRepository repository)
//     : IEventHandler<OpenAnswerExerciseGenerated<TExercise>> where TExercise : OpenAnswerExercise
// {
//     public Task HandleAsync(OpenAnswerExerciseGenerated<TExercise> @event)
//     {
//         var mapped = @event.Exercise.Map();
//         return repository.AddAsync(mapped);
//     }
// }