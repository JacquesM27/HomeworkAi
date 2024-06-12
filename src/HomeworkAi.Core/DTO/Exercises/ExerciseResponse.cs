namespace HomeworkAi.Core.DTO.Exercises;

public class ExerciseResponse
{
    public Exercise Exercise { get; set; }
    
    public bool ExerciseHeaderInMotherLanguage { get; set; }
    public string MotherLanguage { get; set; }
    public string TargetLanguage { get; set; }
    public string TargetLanguageLevel { get; set; }
    public string? TopicsOfSentences { get; set; }
    public string? GrammarSection { get; set; }
    public string AdditionalResources { get; set; }
}