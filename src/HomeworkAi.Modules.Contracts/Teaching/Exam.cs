using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Modules.Contracts.Teaching;

public class Exam
{
    public Guid Id { get; set; }
    //public IEnumerable<IExerciseResponse> Exercises { get; set; }
    public Teacher Teacher { get; set; }
    public Student? IndividualStudent { get; set; }
    public Class? Class { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    public int? LimitInSeconds { get; set; }
    public string? Password { get; set; }
}