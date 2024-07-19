namespace HomeworkAi.Modules.Contracts.Teaching;

public class Class
{
    public Guid Id { get; set; }
    public IEnumerable<Teacher> Teachers { get; set; }
    public IEnumerable<Student> Students { get; set; }
}