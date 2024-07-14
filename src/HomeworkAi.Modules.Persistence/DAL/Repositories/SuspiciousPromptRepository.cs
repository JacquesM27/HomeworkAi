using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL.Repositories;

public interface ISuspiciousPromptRepository
{
    Task AddAsync(SuspiciousPromptEntity suspiciousPrompt);
    Task AddRangeAsync(IEnumerable<SuspiciousPromptEntity> suspiciousPrompts);
}

internal sealed class SuspiciousPromptRepository(HomeworkDbContext dbContext) : ISuspiciousPromptRepository
{
    private readonly DbSet<SuspiciousPromptEntity> _suspiciousPrompts = dbContext.SuspiciousPrompts;

    public async Task AddAsync(SuspiciousPromptEntity suspiciousPrompt)
        => await _suspiciousPrompts.AddAsync(suspiciousPrompt).ConfigureAwait(false);

    public async Task AddRangeAsync(IEnumerable<SuspiciousPromptEntity> suspiciousPrompts)
        => await _suspiciousPrompts.AddRangeAsync(suspiciousPrompts).ConfigureAwait(false);
}