using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Events.Exercises;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.DAL.Entities;
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

internal sealed class OpenAnswerExerciseResponseSentencesTranslationGeneratedHandler(
    IOpenAnswerExerciseRepository repository)
    : IEventHandler<OpenAnswerExerciseResponseSentencesTranslationGenerated>
{
    public Task HandleAsync(OpenAnswerExerciseResponseSentencesTranslationGenerated @event)
    {
        var mapped = @event.Exercise.Map<SentencesTranslation, SentencesTranslationEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class OpenAnswerExerciseResponseSentenceWithVerbToCompleteBasedOnInfinitiveGeneratedHandler(
    IOpenAnswerExerciseRepository repository)
    : IEventHandler<OpenAnswerExerciseResponseSentenceWithVerbToCompleteBasedOnInfinitiveGenerated>
{
    public Task HandleAsync(OpenAnswerExerciseResponseSentenceWithVerbToCompleteBasedOnInfinitiveGenerated @event)
    {
        var mapped = @event.Exercise
            .Map<SentenceWithVerbToCompleteBasedOnInfinitive, SentenceWithVerbToCompleteBasedOnInfinitiveEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class OpenAnswerExerciseResponseSentenceWithVerbToCompleteGeneratedHandler(
    IOpenAnswerExerciseRepository repository)
    : IEventHandler<OpenAnswerExerciseResponseSentenceWithVerbToCompleteGenerated>
{
    public Task HandleAsync(OpenAnswerExerciseResponseSentenceWithVerbToCompleteGenerated @event)
    {
        var mapped = @event.Exercise.Map<SentenceWithVerbToComplete, SentenceWithVerbToCompleteEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class OpenAnswerExerciseResponseIrregularVerbsGeneratedHandler(
    IOpenAnswerExerciseRepository repository)
    : IEventHandler<OpenAnswerExerciseResponseIrregularVerbsGenerated>
{
    public Task HandleAsync(OpenAnswerExerciseResponseIrregularVerbsGenerated @event)
    {
        var mapped = @event.Exercise.Map<IrregularVerbs, IrregularVerbsEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class OpenAnswerExerciseResponseQuestionsToTextGeneratedHandler(
    IOpenAnswerExerciseRepository repository)
    : IEventHandler<OpenAnswerExerciseResponseQuestionsToTextGenerated>
{
    public Task HandleAsync(OpenAnswerExerciseResponseQuestionsToTextGenerated @event)
    {
        var mapped = @event.Exercise.Map<QuestionsToTextOpen, QuestionsToTextOpenEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class OpenAnswerExerciseResponsePassiveSideGeneratedHandler(
    IOpenAnswerExerciseRepository repository)
    : IEventHandler<OpenAnswerExerciseResponsePassiveSideGenerated>
{
    public Task HandleAsync(OpenAnswerExerciseResponsePassiveSideGenerated @event)
    {
        var mapped = @event.Exercise.Map<PassiveSideOpen, PassiveSideOpenEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class OpenAnswerExerciseResponseParaphrasingGeneratedHandler(
    IOpenAnswerExerciseRepository repository)
    : IEventHandler<OpenAnswerExerciseResponseParaphrasingGenerated>
{
    public Task HandleAsync(OpenAnswerExerciseResponseParaphrasingGenerated @event)
    {
        var mapped = @event.Exercise.Map<ParaphrasingOpen, ParaphrasingOpenEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class OpenAnswerExerciseResponseAnswerToQuestionGeneratedHandler(
    IOpenAnswerExerciseRepository repository)
    : IEventHandler<OpenAnswerExerciseResponseAnswerToQuestionGenerated>
{
    public Task HandleAsync(OpenAnswerExerciseResponseAnswerToQuestionGenerated @event)
    {
        var mapped = @event.Exercise.Map<AnswerToQuestionOpen, AnswerToQuestionOpenEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class OpenAnswerExerciseResponseConditionalGeneratedHandler(
    IOpenAnswerExerciseRepository repository)
    : IEventHandler<OpenAnswerExerciseResponseConditionalGenerated>
{
    public Task HandleAsync(OpenAnswerExerciseResponseConditionalGenerated @event)
    {
        var mapped = @event.Exercise.Map<ConditionalOpen, ConditionalOpenEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class OpenAnswerExerciseResponseMissingPhrasalVerbGeneratedHandler(
    IOpenAnswerExerciseRepository repository)
    : IEventHandler<OpenAnswerExerciseResponseMissingPhrasalVerbGenerated>
{
    public Task HandleAsync(OpenAnswerExerciseResponseMissingPhrasalVerbGenerated @event)
    {
        var mapped = @event.Exercise.Map<MissingPhrasalVerbOpen, MissingPhrasalVerbOpenEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class OpenAnswerExerciseResponseMissingWordOrExpressionGeneratedHandler(
    IOpenAnswerExerciseRepository repository)
    : IEventHandler<OpenAnswerExerciseResponseMissingWordOrExpressionGenerated>
{
    public Task HandleAsync(OpenAnswerExerciseResponseMissingWordOrExpressionGenerated @event)
    {
        var mapped = @event.Exercise.Map<MissingWordOrExpressionOpen, MissingWordOrExpressionOpenEntity>();
        return repository.AddAsync(mapped);
    }
}

internal sealed class OpenAnswerExerciseResponseWordMeaningGeneratedHandler(
    IOpenAnswerExerciseRepository repository)
    : IEventHandler<OpenAnswerExerciseResponseWordMeaningGenerated>
{
    public Task HandleAsync(OpenAnswerExerciseResponseWordMeaningGenerated @event)
    {
        var mapped = @event.Exercise.Map<WordMeaningOpen, WordMeaningOpenEntity>();
        return repository.AddAsync(mapped);
    }
}