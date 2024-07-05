using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL;

internal sealed class HomeworkDbContext : DbContext
{
    //holy shit mssql is not good idea to complex objects
    /*
    public DbSet<ExerciseResponse<ClosedAnswerExercise>> ExerciseResponses { get; set; }
    public DbSet<ClosedAnswerExerciseResponse<AnswerToQuestionClosed>> ClosedAnswerExerciseResponses { get; set; }
    public DbSet<AnswerToQuestionClosed> AnswerToQuestionCloseds { get; set; }
    public DbSet<ClosedQuestion> ClosedQuestions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Language> Languages { get; set; }
     */
}