namespace HomeworkAi.Modules.Persistence.DAL.Entities;

public class ClassEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LanguageLevel { get; set; }
    public string MotherLanguage { get; set; }
    public string TargetLanguage { get; set; }
    public List<StudentEntity> Students { get; set; }
    public List<TeacherEntity> Teachers { get; set; }
}