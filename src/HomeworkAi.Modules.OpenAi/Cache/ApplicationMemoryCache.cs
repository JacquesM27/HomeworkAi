using System.Collections.Frozen;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Contracts.ValueObjects;

namespace HomeworkAi.Core.Cache;

public class ApplicationMemoryCache : IApplicationMemoryCache
{
    private readonly FrozenDictionary<string, Type> _exercises;
    private readonly FrozenSet<string> _closedAnswerExercises;
    private readonly FrozenSet<string> _openAnswerExercises;
    private readonly FrozenSet<string> _openFormExercises;
    private readonly FrozenSet<string> _languages;
    
    public ApplicationMemoryCache()
    {
        var allExercises = GetNonAbstractDerivedTypes<Exercise>();
        _exercises = allExercises.ToFrozenDictionary(type => type.Name, type => type);
        _closedAnswerExercises = GetNonAbstractDerivedTypeNames<ClosedAnswerExercise>().ToFrozenSet();
        _openAnswerExercises = GetNonAbstractDerivedTypeNames<OpenAnswerExercise>().ToFrozenSet();
        _openFormExercises = GetNonAbstractDerivedTypeNames<OpenFormExercise>().ToFrozenSet();
        _languages = Language.Languages.ToFrozenSet();
    }
    
    public Type? GetExerciseType(string exerciseName) => _exercises.GetValueOrDefault(exerciseName);

    public IEnumerable<string> GetClosedAnswerExercises() => _closedAnswerExercises;

    public IEnumerable<string> GetOpenAnswerExercises() => _openAnswerExercises;

    public IEnumerable<string> GetOpenFormExercises() => _openFormExercises;

    public IEnumerable<string> GetLanguages() => _languages;

    private static IEnumerable<Type> GetNonAbstractDerivedTypes<T>()
    {
        var baseType = typeof(T);
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        return assemblies.SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsSubclassOf(baseType) && !type.IsAbstract);
    }

    private static IEnumerable<string> GetNonAbstractDerivedTypeNames<T>() 
        => GetNonAbstractDerivedTypes<T>().Select(t => t.Name);
}