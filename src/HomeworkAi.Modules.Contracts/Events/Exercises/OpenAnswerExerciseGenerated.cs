using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Modules.Contracts.Events.Exercises;

// public sealed record OpenAnswerExerciseGenerated<TExercise>(OpenAnswerExerciseResponse<TExercise> Exercise)
//     : IEvent where TExercise : OpenAnswerExercise;

public sealed record OpenAnswerExerciseResponseSentencesTranslationGenerated(
    OpenAnswerExerciseResponseSentencesTranslation Exercise) : IEvent;

public sealed record OpenAnswerExerciseResponseSentenceWithVerbToCompleteBasedOnInfinitiveGenerated(
    OpenAnswerExerciseResponseSentenceWithVerbToCompleteBasedOnInfinitive Exercise) : IEvent;

public sealed record OpenAnswerExerciseResponseSentenceWithVerbToCompleteGenerated(
    OpenAnswerExerciseResponseSentenceWithVerbToComplete Exercise) : IEvent;

public sealed record OpenAnswerExerciseResponseIrregularVerbsGenerated(
    OpenAnswerExerciseResponseIrregularVerbs Exercise) : IEvent;

public sealed record OpenAnswerExerciseResponseQuestionsToTextGenerated(
    OpenAnswerExerciseResponseQuestionsToText Exercise) : IEvent;

public sealed record OpenAnswerExerciseResponsePassiveSideGenerated(OpenAnswerExerciseResponsePassiveSide Exercise)
    : IEvent;

public sealed record OpenAnswerExerciseResponseParaphrasingGenerated(OpenAnswerExerciseResponseParaphrasing Exercise)
    : IEvent;

public sealed record OpenAnswerExerciseResponseAnswerToQuestionGenerated(
    OpenAnswerExerciseResponseAnswerToQuestion Exercise) : IEvent;

public sealed record OpenAnswerExerciseResponseConditionalGenerated(OpenAnswerExerciseResponseConditional Exercise)
    : IEvent;

public sealed record OpenAnswerExerciseResponseMissingPhrasalVerbGenerated(
    OpenAnswerExerciseResponseMissingPhrasalVerb Exercise) : IEvent;

public sealed record OpenAnswerExerciseResponseMissingWordOrExpressionGenerated(
    OpenAnswerExerciseResponseMissingWordOrExpression Exercise) : IEvent;

public sealed record OpenAnswerExerciseResponseWordMeaningGenerated(OpenAnswerExerciseResponseWordMeaning Exercise)
    : IEvent;