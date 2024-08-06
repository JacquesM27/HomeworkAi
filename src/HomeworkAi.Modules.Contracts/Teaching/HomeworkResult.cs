using HomeworkAi.Modules.Contracts.DTOs.Complex;

namespace HomeworkAi.Modules.Contracts.Teaching;

public class HomeworkResult
{
    public Guid Id { get; set; }
    public Homework Homework { get; set; }
    public Student Student { get; set; }
    //TODO: exercises answers

    //maybe dictionary or class exercise-answers??
    public List<OpenFormExerciseAnswerMailDto> Mails { get; set; }
    public List<OpenFormExerciseAnswerEssayDto> Essays { get; set; }
    public List<OpenFormExerciseAnswerSummaryOfTextDto> SummariesOfTexts { get; set; }
}