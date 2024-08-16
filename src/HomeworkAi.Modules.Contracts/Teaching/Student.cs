namespace HomeworkAi.Modules.Contracts.Teaching;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IList<Class> Classes { get; set; }
    public IList<Teacher> IndividualTeachers { get; set; }
}