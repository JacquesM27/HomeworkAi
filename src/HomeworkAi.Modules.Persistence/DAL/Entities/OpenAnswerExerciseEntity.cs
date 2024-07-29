namespace HomeworkAi.Modules.Persistence.DAL.Entities;

public class OpenAnswerExerciseEntity
{
    public Guid Id { get; set; }
    public bool ExerciseHeaderInMotherLanguage { get; set; }
    public string MotherLanguage { get; set; }
    public string TargetLanguage { get; set; }
    public string TargetLanguageLevel { get; set; }
    public string? TopicsOfSentences { get; set; }
    public string? GrammarSection { get; set; }
    public int? AmountOfSentences { get; set; }
    public bool? TranslateFromMotherLanguage { get; set; }
    public bool? QuestionsInMotherLanguage { get; set; }

    public bool? ZeroConditional { get; set; }
    public bool? FirstConditional { get; set; }
    public bool? SecondConditional { get; set; }
    public bool? ThirdConditional { get; set; }

    public bool? ShowMotherLanguage { get; set; }
    public bool? ShowFirstForm { get; set; }
    public string ExerciseJson { get; set; } // JSONB column
    public bool CheckedByTeacher { get; set; }
}

public sealed class SentencesTranslationEntity : OpenAnswerExerciseEntity;

public sealed class SentenceWithVerbToCompleteBasedOnInfinitiveEntity : OpenAnswerExerciseEntity;

public sealed class SentenceWithVerbToCompleteEntity : OpenAnswerExerciseEntity;

public sealed class IrregularVerbsEntity : OpenAnswerExerciseEntity;

public sealed class QuestionsToTextOpenEntity : OpenAnswerExerciseEntity;

public sealed class PassiveSideOpenEntity : OpenAnswerExerciseEntity;

public sealed class ParaphrasingOpenEntity : OpenAnswerExerciseEntity;

public sealed class AnswerToQuestionOpenEntity : OpenAnswerExerciseEntity;

public sealed class ConditionalOpenEntity : OpenAnswerExerciseEntity;

public sealed class MissingPhrasalVerbOpenEntity : OpenAnswerExerciseEntity;

public sealed class MissingWordOrExpressionOpenEntity : OpenAnswerExerciseEntity;

public sealed class WordMeaningOpenEntity : OpenAnswerExerciseEntity;