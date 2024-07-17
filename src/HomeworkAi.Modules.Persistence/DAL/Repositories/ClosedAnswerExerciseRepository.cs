using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL.Repositories;

public interface IClosedAnswerExerciseRepository
{
    Task AddAsync(ClosedAnswerExerciseEntity exercise);
}

internal sealed class ClosedAnswerExerciseRepository(HomeworkDbContext dbContext) : IClosedAnswerExerciseRepository
{
    private readonly DbSet<ClosedAnswerExerciseEntity> _closedAnswerExercises = dbContext.ClosedAnswerExercises;

    public async Task AddAsync(ClosedAnswerExerciseEntity exercise)
    {
        await _closedAnswerExercises.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }
}