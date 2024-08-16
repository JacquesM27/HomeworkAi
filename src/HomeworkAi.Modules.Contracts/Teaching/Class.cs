using HomeworkAi.Modules.Contracts.ValueObjects;

namespace HomeworkAi.Modules.Contracts.Teaching;

public class Class
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LanguageLevel { get; set; }
    public Language MotherLanguage { get; set; }
    public Language TargetLanguage { get; set; }
    public IList<Teacher> Teachers { get; set; }
    public IList<Student> Students { get; set; }
}