using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL.Repositories;

public interface IOpenFormExerciseRepository
{
    Task AddAsync(MailEntity exercise);
    Task AddAsync(EssayEntity exercise);
    Task AddAsync(SummaryOfTextEntity exercise);

    Task<MailEntity?> GetMailAsync(Guid id);
    Task<List<MailEntity>> GetMailsAsync(IEnumerable<Guid> ids);
    Task<EssayEntity?> GetEssayAsync(Guid id);
    Task<List<EssayEntity>> GetEssaysAsync(IEnumerable<Guid> ids);
    Task<SummaryOfTextEntity?> GetSummaryOfTextAsync(Guid id);
    Task<List<SummaryOfTextEntity>> GetSummariesOfTextAsync(IEnumerable<Guid> ids);
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

    public Task<List<MailEntity>> GetMailsAsync(IEnumerable<Guid> ids)
    {
        return _mail.Where(mail => ids.Contains(mail.Id)).ToListAsync();
    }

    public Task<EssayEntity?> GetEssayAsync(Guid id)
    {
        return _essay.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<EssayEntity>> GetEssaysAsync(IEnumerable<Guid> ids)
    {
        return _essay.Where(essay => ids.Contains(essay.Id)).ToListAsync();
    }

    public Task<SummaryOfTextEntity?> GetSummaryOfTextAsync(Guid id)
    {
        return _summaryOfText.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<SummaryOfTextEntity>> GetSummariesOfTextAsync(IEnumerable<Guid> ids)
    {
        return _summaryOfText.Where(sot => ids.Contains(sot.Id)).ToListAsync();
    }
}