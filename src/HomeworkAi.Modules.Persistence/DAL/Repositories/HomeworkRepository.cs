using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL.Repositories;

public interface IHomeworkRepository
{
    Task AddAsync(HomeworkEntity homework);
}

internal sealed class HomeworkRepository(HomeworkDbContext dbContext) : IHomeworkRepository
{
    private readonly DbSet<HomeworkEntity> _homework = dbContext.HomeworkEntities;
    
    public async Task AddAsync(HomeworkEntity homework)
    {
        await _homework.AddAsync(homework);
        await dbContext.SaveChangesAsync();
    }
}