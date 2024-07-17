using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL.Repositories;

public interface IOpenAnswerExerciseRepository
{
    Task AddAsync(OpenAnswerExerciseEntity exercise);
}

internal sealed class OpenAnswerExerciseRepository(HomeworkDbContext dbContext) : IOpenAnswerExerciseRepository
{
    private readonly DbSet<OpenAnswerExerciseEntity> _openAnswerExercises = dbContext.OpenAnswerExercises;

    public async Task AddAsync(OpenAnswerExerciseEntity exercise)
    {
        await _openAnswerExercises.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }
}