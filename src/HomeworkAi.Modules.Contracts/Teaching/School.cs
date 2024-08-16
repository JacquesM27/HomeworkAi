namespace HomeworkAi.Modules.Contracts.Teaching;

public sealed class School
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IList<Teacher> Teachers { get; set; }
    public IList<Class> Classes { get; set; }
}