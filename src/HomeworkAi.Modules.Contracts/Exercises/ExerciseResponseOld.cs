using HomeworkAi.Modules.Contracts.ValueObjects;

namespace HomeworkAi.Modules.Contracts.Exercises;

public abstract class ExerciseResponseOld
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

public sealed class OpenFormExerciseResponseOld : ExerciseResponseOld
{
    public string DescriptionOfExerciseContent { get; set; }
    public bool QuestionsInMotherLanguage { get; set; }
}

public sealed class OpenAnswerExerciseResponseOld : ExerciseResponseOld
{
    public int AmountOfSentences { get; set; }
    public bool AnswersInMotherLanguage { get; set; }
}

public sealed class ClosedAnswerExerciseResponseOld : ExerciseResponseOld
{
    public int AmountOfSentences { get; set; }
    public bool QuestionsInMotherLanguage { get; set; }
    public bool AnswersInMotherLanguage { get; set; }
}
