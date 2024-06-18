using HomeworkAi.Core.ValueObjects;

namespace HomeworkAi.Core.DTO.Exercises;

public abstract class ExerciseResponse
{
    public Exercise Exercise { get; set; }
    
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

public class ExerciseResponseFactory
{
    public ExerciseResponse CreateResponse(Exercise exercise, ExercisePrompt prompt)
    {
           
        if (prompt.GetType().IsInstanceOfType(typeof(OpenFormExercisePrompt)))
        {
            
        }

        if (prompt.GetType().IsInstanceOfType(typeof(OpenAnswerExercisePrompt)))
        {
            
        }
        
        if (prompt.GetType().IsInstanceOfType(typeof(ClosedAnswerExercisePrompt)))
        {
            
        }
        
        throw new NotImplementedException($"Exercise type: '{prompt.GetType().Name}' is not implemented.");
    }
}