namespace HomeworkAi.Modules.Persistence.DAL.Entities;

public abstract class OpenFormExerciseEntity
{
    public Guid Id { get; set; }
    public bool ExerciseHeaderInMotherLanguage { get; set; }
    public string MotherLanguage { get; set; }
    public string TargetLanguage { get; set; }
    public string TargetLanguageLevel { get; set; }
    public string? TopicsOfSentences { get; set; }
    public string? GrammarSection { get; set; }
    public string ExerciseJson { get; set; } // JSONB column

    public bool CheckedByTeacher { get; set; }
    public double AverageRating { get; set; }
    public int RatingCount { get; set; }
}

public sealed class MailEntity : OpenFormExerciseEntity;

public sealed class EssayEntity : OpenFormExerciseEntity;

public sealed class SummaryOfTextEntity : OpenFormExerciseEntity;