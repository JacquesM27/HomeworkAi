using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL;

internal sealed class HomeworkDbContext(DbContextOptions<HomeworkDbContext> dbContextOptions)
    : DbContext(dbContextOptions)
{
    public DbSet<OpenFormExerciseMailEntity> OpenFormExerciseMailEntities { get; set; }
    public DbSet<OpenFormExerciseEssayEntity> OpenFormExerciseEssayEntities { get; set; }
    public DbSet<OpenFormExerciseSummaryOfTextEntity> OpenFormExerciseSummaryOfTextEntities { get; set; }
    
    public DbSet<ClosedAnswerExerciseEntity> ClosedAnswerExercises { get; set; }
    public DbSet<OpenAnswerExerciseEntity> OpenAnswerExercises { get; set; }
    public DbSet<SuspiciousPromptEntity> SuspiciousPrompts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}