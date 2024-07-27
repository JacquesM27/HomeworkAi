using Microsoft.Extensions.DependencyInjection;

namespace HomeworkAi.Infrastructure.Events;

internal sealed class EventDispatcher(IServiceScopeFactory serviceScopeFactory) : IEventDispatcher
{
    //TODO: change events as background service
    public Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
    {
        var handlers = serviceScopeFactory.CreateScope().ServiceProvider.GetServices<IEventHandler<TEvent>>().ToList();

        var tasks = handlers.Select(async _ =>
        {
            using var scope = serviceScopeFactory.CreateScope();
            var scopedHandler = scope.ServiceProvider.GetRequiredService<IEventHandler<TEvent>>();
            await scopedHandler.HandleAsync(@event);
        });

        return Task.WhenAll(tasks);
    }
}