namespace HomeworkAi.Modules.Persistence.DAL.Entities;

public class StudentEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IList<ClassEntity> Classes { get; set; }
    public IList<TeacherEntity> IndividualTeachers { get; set; }
}