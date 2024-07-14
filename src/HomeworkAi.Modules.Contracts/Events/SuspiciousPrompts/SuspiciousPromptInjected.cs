using HomeworkAi.Infrastructure.Events;

namespace HomeworkAi.Modules.Contracts.Events.SuspiciousPrompts;

public sealed record SuspiciousPromptInjected(SuspiciousPrompt SuspiciousPrompt)
    : IEvent;