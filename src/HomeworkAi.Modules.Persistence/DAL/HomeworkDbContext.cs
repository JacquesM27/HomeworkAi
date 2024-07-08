using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL;

internal sealed class HomeworkDbContext(DbContextOptions<HomeworkDbContext> dbContextOptions)
    : DbContext(dbContextOptions)
{
    public DbSet<ClosedAnswerExerciseEntity> ClosedAnswerExercises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}