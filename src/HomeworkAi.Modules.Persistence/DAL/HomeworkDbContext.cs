using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL;

internal sealed class HomeworkDbContext(DbContextOptions<HomeworkDbContext> dbContextOptions)
    : DbContext(dbContextOptions)
{
    public DbSet<OpenFormExerciseMailEntity> OpenFormExerciseMailEntities { get; set; }
    public DbSet<OpenFormExerciseEssayEntity> OpenFormExerciseEssayEntities { get; set; }
    public DbSet<OpenFormExerciseSummaryOfTextEntity> OpenFormExerciseSummaryOfTextEntities { get; set; }

    public DbSet<ClosedAnswerExerciseResponseQuestionsToTextEntity> ClosedAnswerExerciseResponseQuestionsToTextEntities
    {
        get;
        set;
    }

    public DbSet<ClosedAnswerExerciseResponsePassiveSideEntity> ClosedAnswerExerciseResponsePassiveSideEntities
    {
        get;
        set;
    }

    public DbSet<ClosedAnswerExerciseResponseParaphrasingEntity> ClosedAnswerExerciseResponseParaphrasingEntities
    {
        get;
        set;
    }

    public DbSet<ClosedAnswerExerciseResponseAnswerToQuestionEntity>
        ClosedAnswerExerciseResponseAnswerToQuestionEntities { get; set; }

    public DbSet<ClosedAnswerExerciseResponseConditionalEntity> ClosedAnswerExerciseResponseConditionalEntities
    {
        get;
        set;
    }

    public DbSet<ClosedAnswerExerciseResponseWordMeaningEntity> ClosedAnswerExerciseResponseWordMeaningEntities
    {
        get;
        set;
    }

    public DbSet<ClosedAnswerExerciseResponsePhrasalVerbsTranslatingEntity>
        ClosedAnswerExerciseResponsePhrasalVerbsTranslatingEntities { get; set; }

    public DbSet<ClosedAnswerExerciseResponseMissingPhrasalVerbEntity>
        ClosedAnswerExerciseResponseMissingPhrasalVerbEntities { get; set; }

    public DbSet<ClosedAnswerExerciseResponseMissingWordOrExpressionEntity>
        ClosedAnswerExerciseResponseMissingWordOrExpressionEntities { get; set; }


    public DbSet<OpenAnswerExerciseEntity> OpenAnswerExercises { get; set; }
    public DbSet<SuspiciousPromptEntity> SuspiciousPrompts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}