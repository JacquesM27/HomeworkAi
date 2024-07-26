using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Modules.Contracts.Events.Exercises;

// public abstract record ClosedAnswerExerciseGenerated<TExercise>(ClosedAnswerExerciseResponse<TExercise> Exercise) 
//     : IEvent where TExercise : ClosedAnswerExercise;
    
public sealed record ClosedAnswerExerciseResponseQuestionsToTextGenerated
    (ClosedAnswerExerciseResponseQuestionsToText Exercise): IEvent;
    
public sealed record ClosedAnswerExerciseResponsePassiveSideGenerated
    (ClosedAnswerExerciseResponsePassiveSide Exercise): IEvent;    
    
public sealed record ClosedAnswerExerciseResponseParaphrasingGenerated
    (ClosedAnswerExerciseResponseParaphrasing Exercise): IEvent;    

public sealed record ClosedAnswerExerciseResponseAnswerToQuestionGenerated
    (ClosedAnswerExerciseResponseAnswerToQuestion Exercise): IEvent;    

public sealed record ClosedAnswerExerciseResponseConditionalGenerated
    (ClosedAnswerExerciseResponseConditional Exercise): IEvent;    

public sealed record ClosedAnswerExerciseResponseWordMeaningGenerated
    (ClosedAnswerExerciseResponseWordMeaning Exercise): IEvent;    

public sealed record ClosedAnswerExerciseResponsePhrasalVerbsTranslatingGenerated
    (ClosedAnswerExerciseResponsePhrasalVerbsTranslating Exercise): IEvent;    

public sealed record ClosedAnswerExerciseResponseMissingPhrasalVerbGenerated
    (ClosedAnswerExerciseResponseMissingPhrasalVerb Exercise): IEvent;    

public sealed record ClosedAnswerExerciseResponseMissingWordOrExpressionGenerated
    (ClosedAnswerExerciseResponseMissingWordOrExpression Exercise): IEvent;    