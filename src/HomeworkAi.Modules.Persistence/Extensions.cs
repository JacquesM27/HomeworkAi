using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.DAL;
using HomeworkAi.Modules.Persistence.Events.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HomeworkAi.Infrastructure.ReflectionExtensions;
using HomeworkAi.Modules.Contracts.Events.Exercises;

namespace HomeworkAi.Modules.Persistence;

public static class Extensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);

        // services.AddAllHandlersForExercises<ClosedAnswerExercise>(
        //     typeof(ClosedAnswerExerciseGenerated<>),
        //     typeof(ClosedAnswerExerciseGeneratedHandler<>));
        //
        // services.AddAllHandlersForExercises<OpenAnswerExercise>(
        //     typeof(OpenAnswerExerciseGenerated<>),
        //     typeof(OpenAnswerExerciseGeneratedHandler<>));
        //
        // services.AddAllHandlersForExercises<OpenFormExercise>(
        //     typeof(OpenFormExerciseGenerated<>),
        //     typeof(OpenFormExerciseGeneratedHandler<>));

        return services;
    }

    // private static IServiceCollection AddAllHandlersForExercises<TExercise>(
    //     this IServiceCollection services,
    //     Type eventType,
    //     Type eventHandlerType)
    // {
    //     var exerciseTypes = TypesExtensions.GetNonAbstractDerivedTypes<TExercise>();
    //
    //     foreach (var exerciseType in exerciseTypes)
    //     {
    //         var constructedEventType = eventType.MakeGenericType(exerciseType);
    //         var constructedEventHandlerType = eventHandlerType.MakeGenericType(exerciseType);
    //         var handlerInterfaceType = typeof(IEventHandler<>).MakeGenericType(constructedEventType);
    //
    //         services.AddScoped(handlerInterfaceType, constructedEventHandlerType);
    //     }
    //
    //     return services;
    // }
}