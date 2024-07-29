using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.DAL.Entities;
using HomeworkAi.Modules.Persistence.DAL.Repositories;
using HomeworkAi.Modules.Persistence.Events.Mappers;

namespace HomeworkAi.Modules.Persistence.Events.Handlers;

internal sealed class OpenFormExerciseMailGeneratedHandler(IOpenFormExerciseRepository repository)
    : IEventHandler<OpenFormExerciseResponseMailGenerated>
{
    public Task HandleAsync(OpenFormExerciseResponseMailGenerated @event)
    {
        var mapped = @event.Exercise.Map<Mail, MailEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class OpenFormExerciseEssayGeneratedHandler(IOpenFormExerciseRepository repository)
    : IEventHandler<OpenFormExerciseResponseEssayGenerated>
{
    public Task HandleAsync(OpenFormExerciseResponseEssayGenerated @event)
    {
        var mapped = @event.Exercise.Map<Essay, EssayEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class OpenFormExerciseSummaryOfTextGeneratedHandler(IOpenFormExerciseRepository repository)
    : IEventHandler<OpenFormExerciseResponseSummaryOfTextGenerated>
{
    public Task HandleAsync(OpenFormExerciseResponseSummaryOfTextGenerated @event)
    {
        var mapped = @event.Exercise.Map<SummaryOfText, SummaryOfTextEntity>();
        return repository.AddAsync(mapped);
    }
}