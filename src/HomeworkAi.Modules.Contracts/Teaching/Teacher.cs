namespace HomeworkAi.Modules.Contracts.Teaching;

public sealed class Teacher
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IList<Student> IndividualStudents { get; set; }
    public IList<Class> Classes { get; set; }
}