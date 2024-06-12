using System.Collections.Concurrent;
using HomeworkAi.Core.DTO.Exercises;

namespace HomeworkAi.Core.Services;

public interface IExerciseFormatProvider
{
    public string FormatType(string exerciseType);
}

public class ExerciseFormatProvider(IObjectSamplerProvider objectSamplerProvider) : IExerciseFormatProvider
{
    private static readonly ConcurrentDictionary<string, string> _exerciseTypes = [];
    
    public string FormatType(string exerciseType)
    {
        if (_exerciseTypes.TryGetValue(exerciseType, out var json))
            return json;

        if (!Exercises._exercises.TryGetValue(exerciseType, out var type))
            throw new ArgumentOutOfRangeException();//TODO: custom class

        var sample = objectSamplerProvider.GetSampleJson(type);
        _exerciseTypes.TryAdd(exerciseType, sample);
        return sample;
    }
}


public static class Exercises
{
    public static readonly ConcurrentDictionary<string, Type> _exercises = [];

    static Exercises()
    {
        //TODO: maybe reflection
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
        
        _exercises.TryAdd(nameof(MailExercise),(typeof(MailExercise)));
        _exercises.TryAdd(nameof(Essay),(typeof(Essay)));
        _exercises.TryAdd(nameof(SummaryOfText),(typeof(SummaryOfText)));
    }
}