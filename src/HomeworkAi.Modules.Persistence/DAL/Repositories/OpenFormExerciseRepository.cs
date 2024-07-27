using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL.Repositories;

public interface IOpenFormExerciseRepository
{
    Task AddAsync(OpenFormExerciseMailEntity exercise);
    Task AddAsync(OpenFormExerciseEssayEntity exercise);
    Task AddAsync(OpenFormExerciseSummaryOfTextEntity exercise);
}

internal sealed class OpenFormExerciseRepository(HomeworkDbContext dbContext) : IOpenFormExerciseRepository
{
    private readonly DbSet<OpenFormExerciseMailEntity> _mail = dbContext.OpenFormExerciseMailEntities;
    private readonly DbSet<OpenFormExerciseEssayEntity> _essay = dbContext.OpenFormExerciseEssayEntities;
    private readonly DbSet<OpenFormExerciseSummaryOfTextEntity> _summaryOfText = dbContext.OpenFormExerciseSummaryOfTextEntities;
    public async Task AddAsync(OpenFormExerciseMailEntity exercise)
    {
        await _mail.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(OpenFormExerciseEssayEntity exercise)
    {
        await _essay.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(OpenFormExerciseSummaryOfTextEntity exercise)
    {
        await _summaryOfText.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }
}