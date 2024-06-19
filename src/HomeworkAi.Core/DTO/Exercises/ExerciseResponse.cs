using HomeworkAi.Core.ValueObjects;

namespace HomeworkAi.Core.DTO.Exercises;

public abstract class ExerciseResponse
{
    public object Exercise { get; set; }

    public string ExerciseType { get; set; }
    public bool ExerciseHeaderInMotherLanguage { get; set; }
    public Language MotherLanguage { get; set; }
    public Language TargetLanguage { get; set; }
    public string TargetLanguageLevel { get; set; }
    public string? TopicsOfSentences { get; set; }
    public string? GrammarSection { get; set; }
    public string SupportMaterial { get; set; }
}

public sealed class OpenFormExerciseResponse : ExerciseResponse
{
    public string DescriptionOfExerciseContent { get; set; }
    public bool QuestionsInMotherLanguage { get; set; }
}

public sealed class OpenAnswerExerciseResponse : ExerciseResponse
{
    public int AmountOfSentences { get; set; }
    public bool AnswersInMotherLanguage { get; set; }
}

public sealed class ClosedAnswerExerciseResponse : ExerciseResponse
{
    public int AmountOfSentences { get; set; }
    public bool QuestionsInMotherLanguage { get; set; }
    public bool AnswersInMotherLanguage { get; set; }
}