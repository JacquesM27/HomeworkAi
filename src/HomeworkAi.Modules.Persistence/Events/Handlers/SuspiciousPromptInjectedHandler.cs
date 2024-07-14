using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Events.SuspiciousPrompts;
using HomeworkAi.Modules.Persistence.DAL.Entities;
using HomeworkAi.Modules.Persistence.DAL.Repositories;

namespace HomeworkAi.Modules.Persistence.Events.Handlers;

internal sealed class SuspiciousPromptInjectedHandler(ISuspiciousPromptRepository repository)
    : IEventHandler<SuspiciousPromptInjected>
{
    public Task HandleAsync(SuspiciousPromptInjected @event)
    {
        var mapped = @event.SuspiciousPrompt.Reasons
            .Select(x => new SuspiciousPromptEntity()
            {
                Id = Guid.NewGuid(),
                Reason = x
            });
        return repository.AddRangeAsync(mapped);
    }
}