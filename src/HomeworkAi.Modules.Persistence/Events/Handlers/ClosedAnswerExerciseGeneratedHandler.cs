using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.DAL.Entities;
using HomeworkAi.Modules.Persistence.DAL.Repositories;
using HomeworkAi.Modules.Persistence.Events.Mappers;

namespace HomeworkAi.Modules.Persistence.Events.Handlers;

internal sealed class ClosedAnswerExerciseResponseQuestionsToTextGeneratedHandler(
    IClosedAnswerExerciseRepository repository)
    : IEventHandler<ClosedAnswerExerciseResponseQuestionsToTextGenerated>
{
    public Task HandleAsync(ClosedAnswerExerciseResponseQuestionsToTextGenerated @event)
    {
        var mapped = @event.Exercise.Map<QuestionsToTextClosed, ClosedAnswerExerciseResponseQuestionsToTextEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class ClosedAnswerExerciseResponsePassiveSideGeneratedHandler(
    IClosedAnswerExerciseRepository repository)
    : IEventHandler<ClosedAnswerExerciseResponsePassiveSideGenerated>
{
    public Task HandleAsync(ClosedAnswerExerciseResponsePassiveSideGenerated @event)
    {
        var mapped = @event.Exercise.Map<PassiveSideClosed, ClosedAnswerExerciseResponsePassiveSideEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class ClosedAnswerExerciseResponseParaphrasingGeneratedHandler(
    IClosedAnswerExerciseRepository repository)
    : IEventHandler<ClosedAnswerExerciseResponseParaphrasingGenerated>
{
    public Task HandleAsync(ClosedAnswerExerciseResponseParaphrasingGenerated @event)
    {
        var mapped = @event.Exercise.Map<ParaphrasingClosed, ClosedAnswerExerciseResponseParaphrasingEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class ClosedAnswerExerciseResponseAnswerToQuestionGeneratedHandler(
    IClosedAnswerExerciseRepository repository)
    : IEventHandler<ClosedAnswerExerciseResponseAnswerToQuestionGenerated>
{
    public Task HandleAsync(ClosedAnswerExerciseResponseAnswerToQuestionGenerated @event)
    {
        var mapped = @event.Exercise.Map<AnswerToQuestionClosed, ClosedAnswerExerciseResponseAnswerToQuestionEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class ClosedAnswerExerciseResponseConditionalGeneratedHandler(
    IClosedAnswerExerciseRepository repository)
    : IEventHandler<ClosedAnswerExerciseResponseConditionalGenerated>
{
    public Task HandleAsync(ClosedAnswerExerciseResponseConditionalGenerated @event)
    {
        var mapped = @event.Exercise.Map<ConditionalClosed, ClosedAnswerExerciseResponseConditionalEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class ClosedAnswerExerciseResponseWordMeaningGeneratedHandler(
    IClosedAnswerExerciseRepository repository)
    : IEventHandler<ClosedAnswerExerciseResponseWordMeaningGenerated>
{
    public Task HandleAsync(ClosedAnswerExerciseResponseWordMeaningGenerated @event)
    {
        var mapped = @event.Exercise.Map<WordMeaningClosed, ClosedAnswerExerciseResponseWordMeaningEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class ClosedAnswerExerciseResponsePhrasalVerbsTranslatingGeneratedHandler(
    IClosedAnswerExerciseRepository repository)
    : IEventHandler<ClosedAnswerExerciseResponsePhrasalVerbsTranslatingGenerated>
{
    public Task HandleAsync(ClosedAnswerExerciseResponsePhrasalVerbsTranslatingGenerated @event)
    {
        var mapped = @event.Exercise
            .Map<PhrasalVerbsTranslating, ClosedAnswerExerciseResponsePhrasalVerbsTranslatingEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class ClosedAnswerExerciseResponseMissingPhrasalVerbGeneratedHandler(
    IClosedAnswerExerciseRepository repository)
    : IEventHandler<ClosedAnswerExerciseResponseMissingPhrasalVerbGenerated>
{
    public Task HandleAsync(ClosedAnswerExerciseResponseMissingPhrasalVerbGenerated @event)
    {
        var mapped =
            @event.Exercise.Map<MissingPhrasalVerbClosed, ClosedAnswerExerciseResponseMissingPhrasalVerbEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class ClosedAnswerExerciseResponseMissingWordOrExpressionGeneratedHandler(
    IClosedAnswerExerciseRepository repository)
    : IEventHandler<ClosedAnswerExerciseResponseMissingWordOrExpressionGenerated>
{
    public Task HandleAsync(ClosedAnswerExerciseResponseMissingWordOrExpressionGenerated @event)
    {
        var mapped = @event.Exercise
            .Map<MissingWordOrExpressionClosed, ClosedAnswerExerciseResponseMissingWordOrExpressionEntity>();
        return repository.AddAsync(mapped);
    }
}