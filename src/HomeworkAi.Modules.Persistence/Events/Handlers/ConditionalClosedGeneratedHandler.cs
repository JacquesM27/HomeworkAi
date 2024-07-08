using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Events.Exercises.ClosedAnswer;
using HomeworkAi.Modules.Persistence.DAL.Repositories;

namespace HomeworkAi.Modules.Persistence.Events.Handlers;

internal sealed class ConditionalClosedGeneratedHandler(IClosedAnswerExerciseRepository repository)
    : IEventHandler<ConditionalClosedGenerated>
{
    public Task HandleAsync(ConditionalClosedGenerated @event)
    {
        throw new NotImplementedException();
    }
}