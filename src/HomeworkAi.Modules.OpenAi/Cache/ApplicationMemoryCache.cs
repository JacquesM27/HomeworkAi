using System.Collections.Frozen;
using HomeworkAi.Infrastructure.ReflectionExtensions;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Contracts.ValueObjects;

namespace HomeworkAi.Modules.OpenAi.Cache;

public class ApplicationMemoryCache : IApplicationMemoryCache
{
    private readonly FrozenDictionary<string, Type> _exercises;
    private readonly FrozenSet<string> _closedAnswerExercises;
    private readonly FrozenSet<string> _openAnswerExercises;
    private readonly FrozenSet<string> _openFormExercises;
    private readonly FrozenSet<string> _languages;
    
    public ApplicationMemoryCache()
    {
        var allExercises = TypesExtensions.GetNonAbstractDerivedTypes<Exercise>();
        _exercises = allExercises.ToFrozenDictionary(type => type.Name, type => type);
        _closedAnswerExercises = TypesExtensions.GetNonAbstractDerivedTypeNames<ClosedAnswerExercise>().ToFrozenSet();
        _openAnswerExercises = TypesExtensions.GetNonAbstractDerivedTypeNames<OpenAnswerExercise>().ToFrozenSet();
        _openFormExercises = TypesExtensions.GetNonAbstractDerivedTypeNames<OpenFormExercise>().ToFrozenSet();
        _languages = Language.Languages.ToFrozenSet();
    }
    
    public Type? GetExerciseType(string exerciseName) => _exercises.GetValueOrDefault(exerciseName);

    public IEnumerable<string> GetClosedAnswerExercises() => _closedAnswerExercises;

    public IEnumerable<string> GetOpenAnswerExercises() => _openAnswerExercises;

    public IEnumerable<string> GetOpenFormExercises() => _openFormExercises;

    public IEnumerable<string> GetLanguages() => _languages;
}