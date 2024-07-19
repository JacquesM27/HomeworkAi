namespace HomeworkAi.Modules.Contracts.Teaching;

public sealed class School
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Teacher> SchoolAdmins { get; set; }
    public IEnumerable<Class> Classes { get; set; }
}