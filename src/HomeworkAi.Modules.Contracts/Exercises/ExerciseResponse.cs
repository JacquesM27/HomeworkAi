using HomeworkAi.Modules.Contracts.ValueObjects;

namespace HomeworkAi.Modules.Contracts.Exercises;

public abstract class ExerciseResponse<TExercise>
{
    public TExercise Exercise { get; set; }
    public bool ExerciseHeaderInMotherLanguage { get; set; }
    public Language MotherLanguage { get; set; }
    public Language TargetLanguage { get; set; }
    public string TargetLanguageLevel { get; set; }
    public string? TopicsOfSentences { get; set; }
    public string? GrammarSection { get; set; }
}

public class OpenFormExerciseResponse<TExercise> : ExerciseResponse<TExercise>
    where TExercise : OpenFormExercise
{
    
}

public class OpenAnswerExerciseResponse<TExercise> : ExerciseResponse<TExercise>
    where TExercise : OpenAnswerExercise
{
    public int AmountOfSentences { get; set; }
    public bool TranslateFromMotherLanguage { get; set; }
}