using System.Collections.Frozen;
using HomeworkAi.Core.DTO.Exercises;
using HomeworkAi.Core.Entities;
using Microsoft.Extensions.Caching.Memory;

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
/*
public static class Exercises
{
    public static readonly ConcurrentDictionary<string, Type> _exercises = [];

    static Exercises()
    {
        _exercises.TryAdd(nameof(QuestionsToTextClosed),(typeof(QuestionsToTextClosed)));
        _exercises.TryAdd(nameof(PassiveSideClosed),(typeof(PassiveSideClosed)));
        _exercises.TryAdd(nameof(ParaphrasingClosed),(typeof(ParaphrasingClosed)));
        _exercises.TryAdd(nameof(AnswerToQuestionClosed),(typeof(AnswerToQuestionClosed)));
        _exercises.TryAdd(nameof(ConditionalClosed),(typeof(ConditionalClosed)));
        _exercises.TryAdd(nameof(SentenceFormationClosed),(typeof(SentenceFormationClosed)));
        _exercises.TryAdd(nameof(WordMeaning),(typeof(WordMeaning)));
        _exercises.TryAdd(nameof(PhrasalVerbsTranslating),(typeof(PhrasalVerbsTranslating)));
        _exercises.TryAdd(nameof(MissingPhrasalVerbsClosed),(typeof(MissingPhrasalVerbsClosed)));
        _exercises.TryAdd(nameof(MissingWordOrExpressionClosed),(typeof(MissingWordOrExpressionClosed)));
        //10
        
        _exercises.TryAdd(nameof(SentencesTranscription),(typeof(SentencesTranscription)));
        _exercises.TryAdd(nameof(SentenceWithVerbToCompleteBasedOnInfinitive),(typeof(SentenceWithVerbToCompleteBasedOnInfinitive)));
        _exercises.TryAdd(nameof(SentenceWithVerbToComplete),(typeof(SentenceWithVerbToComplete)));
        _exercises.TryAdd(nameof(IrregularVerbs),(typeof(IrregularVerbs)));
        _exercises.TryAdd(nameof(QuestionsToTextOpen),(typeof(QuestionsToTextOpen)));
        _exercises.TryAdd(nameof(PassiveSideOpen),(typeof(PassiveSideOpen)));
        _exercises.TryAdd(nameof(ParaphrasingOpen),(typeof(ParaphrasingOpen)));
        _exercises.TryAdd(nameof(AnswerToQuestionOpen),(typeof(AnswerToQuestionOpen)));
        _exercises.TryAdd(nameof(ConditionalOpen),(typeof(ConditionalOpen)));
        _exercises.TryAdd(nameof(MissingPhrasalVerbsOpen),(typeof(MissingPhrasalVerbsOpen)));
        _exercises.TryAdd(nameof(MissingWordOrExpressionOpen),(typeof(MissingWordOrExpressionOpen)));
        //11
        
        _exercises.TryAdd(nameof(MailExercise),(typeof(MailExercise)));
        _exercises.TryAdd(nameof(Essay),(typeof(Essay)));
        _exercises.TryAdd(nameof(SummaryOfText),(typeof(SummaryOfText)));
        //3
    }
}
*/