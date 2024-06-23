using HomeworkAi.Modules.Contracts.ValueObjects;

namespace HomeworkAi.Modules.OpenAi.Queries;

public abstract record ExerciseQueryBase
{
    public bool ExerciseHeaderInMotherLanguage { get; set; }
    public Language MotherLanguage { get; set; }
    public Language TargetLanguage { get; set; }
    public string TargetLanguageLevel { get; set; }
    public string? TopicsOfSentences { get; set; }
    public string? GrammarSection { get; set; }
    public string? SupportMaterial { get; set; }
}