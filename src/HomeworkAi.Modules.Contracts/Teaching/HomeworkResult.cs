namespace HomeworkAi.Modules.Contracts.Teaching;

public class HomeworkResult
{
    public Guid Id { get; set; }
    public Homework Homework { get; set; }
    public Student Student { get; set; }
    //TODO: exercises answers

    //maybe dictionary or class exercise-answers??
}