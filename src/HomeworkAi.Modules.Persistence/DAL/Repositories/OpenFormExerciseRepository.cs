using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL.Repositories;

public interface IOpenFormExerciseRepository
{
    Task AddAsync(MailEntity exercise);
    Task AddAsync(EssayEntity exercise);
    Task AddAsync(SummaryOfTextEntity exercise);

    Task<MailEntity?> GetMailAsync(Guid id);
    Task<EssayEntity?> GetEssayAsync(Guid id);
    Task<SummaryOfTextEntity?> GetSummaryOfTextAsync(Guid id);
}

internal sealed class OpenFormExerciseRepository(HomeworkDbContext dbContext) : IOpenFormExerciseRepository
{
    private readonly DbSet<MailEntity> _mail = dbContext.MailEntities;
    private readonly DbSet<EssayEntity> _essay = dbContext.EssayEntities;

    private readonly DbSet<SummaryOfTextEntity> _summaryOfText =
        dbContext.SummaryOfTextEntities;

    public async Task AddAsync(MailEntity exercise)
    {
        await _mail.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(EssayEntity exercise)
    {
        await _essay.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(SummaryOfTextEntity exercise)
    {
        await _summaryOfText.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public Task<MailEntity?> GetMailAsync(Guid id)
    {
        return _mail.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<EssayEntity?> GetEssayAsync(Guid id)
    {
        return _essay.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<SummaryOfTextEntity?> GetSummaryOfTextAsync(Guid id)
    {
        return _summaryOfText.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}