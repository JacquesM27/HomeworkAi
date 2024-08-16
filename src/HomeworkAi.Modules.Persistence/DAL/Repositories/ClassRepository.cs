using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL.Repositories;

public interface IClassRepository
{
    Task<ClassEntity?> Get(Guid id);
}

internal sealed class ClassRepository(HomeworkDbContext dbContext) : IClassRepository
{
    private readonly DbSet<ClassEntity> _classes = dbContext.ClassEntities;

    public Task<ClassEntity?> Get(Guid id)
        => _classes.Where(cls => cls.Id == id).SingleOrDefaultAsync();
}