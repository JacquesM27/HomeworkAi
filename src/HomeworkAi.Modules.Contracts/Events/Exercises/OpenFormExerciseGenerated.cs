using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Modules.Contracts.Events.Exercises;

// public sealed record OpenFormExerciseGenerated<TExercise>(OpenFormExerciseResponse<TExercise> Exercise)
//     : IEvent where TExercise : OpenFormExercise;

public sealed record OpenFormExerciseResponseMailGenerated
    (OpenFormExerciseResponseMail Exercise): IEvent;  

public sealed record OpenFormExerciseResponseEssayGenerated
    (OpenFormExerciseResponseEssay Exercise): IEvent;   

public sealed record OpenFormExerciseResponseSummaryOfTextGenerated
    (OpenFormExerciseResponseSummaryOfText Exercise): IEvent;     