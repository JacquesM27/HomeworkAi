using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL.Repositories;

public interface IOpenFormExerciseRepository
{
    Task AddAsync(OpenFormExerciseEntity exercise);
}

internal sealed class OpenFormExerciseRepository(HomeworkDbContext dbContext) : IOpenFormExerciseRepository
{
    private readonly DbSet<OpenFormExerciseEntity> _openFormExercises = dbContext.OpenFormExercises;

    public async Task AddAsync(OpenFormExerciseEntity exercise)
    {
        await _openFormExercises.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }
}