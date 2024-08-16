using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL.Repositories;

public interface IClosedAnswerExerciseRepository
{
    Task AddAsync(QuestionsToTextClosedEntity exercise);
    Task AddAsync(PassiveSideClosedEntity exercise);
    Task AddAsync(ParaphrasingClosedEntity exercise);
    Task AddAsync(AnswerToQuestionClosedEntity exercise);
    Task AddAsync(ConditionalClosedEntity exercise);
    Task AddAsync(WordMeaningClosedEntity exercise);
    Task AddAsync(PhrasalVerbsTranslatingEntity exercise);
    Task AddAsync(MissingPhrasalVerbClosedEntity exercise);
    Task AddAsync(MissingWordOrExpressionClosedEntity exercise);

    Task<QuestionsToTextClosedEntity?> GetQuestionsToTextAsync(Guid id);
    Task<List<QuestionsToTextClosedEntity>> GetQuestionsToTextAsync(IEnumerable<Guid> ids);
    Task<PassiveSideClosedEntity?> GetPassiveSideAsync(Guid id);
    Task<List<PassiveSideClosedEntity>> GetPassiveSideAsync(IEnumerable<Guid> ids);
    Task<ParaphrasingClosedEntity?> GetParaphrasingAsync(Guid id);
    Task<List<ParaphrasingClosedEntity>> GetParaphrasingAsync(IEnumerable<Guid> ids);
    Task<AnswerToQuestionClosedEntity?> GetAnswerToQuestionAsync(Guid id);
    Task<List<AnswerToQuestionClosedEntity>> GetAnswerToQuestionAsync(IEnumerable<Guid> ids);
    Task<ConditionalClosedEntity?> GetConditionalAsync(Guid id);
    Task<List<ConditionalClosedEntity>> GetConditionalAsync(IEnumerable<Guid> ids);
    Task<WordMeaningClosedEntity?> GetWordMeaningAsync(Guid id);
    Task<List<WordMeaningClosedEntity>> GetWordMeaningAsync(IEnumerable<Guid> ids);
    Task<PhrasalVerbsTranslatingEntity?> GetPhrasalVerbsTranslatingAsync(Guid id);
    Task<List<PhrasalVerbsTranslatingEntity>> GetPhrasalVerbsTranslatingAsync(IEnumerable<Guid> ids);
    Task<MissingPhrasalVerbClosedEntity?> GetMissingPhrasalVerbAsync(Guid id);
    Task<List<MissingPhrasalVerbClosedEntity>> GetMissingPhrasalVerbAsync(IEnumerable<Guid> ids);
    Task<MissingWordOrExpressionClosedEntity?> GetMissingWordOrExpressionAsync(Guid id);
    Task<List<MissingWordOrExpressionClosedEntity>> GetMissingWordOrExpressionAsync(IEnumerable<Guid> id);
}

internal sealed class ClosedAnswerExerciseRepository(HomeworkDbContext dbContext) : IClosedAnswerExerciseRepository
{
    private readonly DbSet<QuestionsToTextClosedEntity> _questionsToText =
        dbContext.QuestionsToTextClosedEntities;

    private readonly DbSet<PassiveSideClosedEntity> _passiveSide =
        dbContext.PassiveSideClosedEntities;

    private readonly DbSet<ParaphrasingClosedEntity> _paraphrasing =
        dbContext.ParaphrasingClosedEntities;

    private readonly DbSet<AnswerToQuestionClosedEntity> _answerToQuestion =
        dbContext.AnswerToQuestionClosedEntities;

    private readonly DbSet<ConditionalClosedEntity> _conditional =
        dbContext.ConditionalClosedEntities;

    private readonly DbSet<WordMeaningClosedEntity> _wordMeaning =
        dbContext.WordMeaningClosedEntities;

    private readonly DbSet<PhrasalVerbsTranslatingEntity> _phrasalVerbs =
        dbContext.PhrasalVerbsTranslatingEntities;

    private readonly DbSet<MissingPhrasalVerbClosedEntity> _missingPhrasalVerb =
        dbContext.MissingPhrasalVerbClosedEntities;

    private readonly DbSet<MissingWordOrExpressionClosedEntity> _missingWordOrExpression =
        dbContext.MissingWordOrExpressionClosedEntities;

    public async Task AddAsync(QuestionsToTextClosedEntity exercise)
    {
        await _questionsToText.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(PassiveSideClosedEntity exercise)
    {
        await _passiveSide.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(ParaphrasingClosedEntity exercise)
    {
        await _paraphrasing.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(AnswerToQuestionClosedEntity exercise)
    {
        await _answerToQuestion.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(ConditionalClosedEntity exercise)
    {
        await _conditional.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(WordMeaningClosedEntity exercise)
    {
        await _wordMeaning.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(PhrasalVerbsTranslatingEntity exercise)
    {
        await _phrasalVerbs.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(MissingPhrasalVerbClosedEntity exercise)
    {
        await _missingPhrasalVerb.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(MissingWordOrExpressionClosedEntity exercise)
    {
        await _missingWordOrExpression.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public Task<QuestionsToTextClosedEntity?> GetQuestionsToTextAsync(Guid id)
    {
        return _questionsToText.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<QuestionsToTextClosedEntity>> GetQuestionsToTextAsync(IEnumerable<Guid> ids)
    {
        return _questionsToText.Where(q => ids.Contains(q.Id)).ToListAsync();
    }

    public Task<PassiveSideClosedEntity?> GetPassiveSideAsync(Guid id)
    {
        return _passiveSide.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<PassiveSideClosedEntity>> GetPassiveSideAsync(IEnumerable<Guid> ids)
    {
        return _passiveSide.Where(ps => ids.Contains(ps.Id)).ToListAsync();
    }

    public Task<ParaphrasingClosedEntity?> GetParaphrasingAsync(Guid id)
    {
        return _paraphrasing.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<ParaphrasingClosedEntity>> GetParaphrasingAsync(IEnumerable<Guid> ids)
    {
        return _paraphrasing.Where(p => ids.Contains(p.Id)).ToListAsync();
    }

    public Task<AnswerToQuestionClosedEntity?> GetAnswerToQuestionAsync(Guid id)
    {
        return _answerToQuestion.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<AnswerToQuestionClosedEntity>> GetAnswerToQuestionAsync(IEnumerable<Guid> ids)
    {
        return _answerToQuestion.Where(atq => ids.Contains(atq.Id)).ToListAsync();
    }

    public Task<ConditionalClosedEntity?> GetConditionalAsync(Guid id)
    {
        return _conditional.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<ConditionalClosedEntity>> GetConditionalAsync(IEnumerable<Guid> ids)
    {
        return _conditional.Where(c => ids.Contains(c.Id)).ToListAsync();
    }

    public Task<WordMeaningClosedEntity?> GetWordMeaningAsync(Guid id)
    {
        return _wordMeaning.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<WordMeaningClosedEntity>> GetWordMeaningAsync(IEnumerable<Guid> ids)
    {
        return _wordMeaning.Where(wm => ids.Contains(wm.Id)).ToListAsync();
    }

    public Task<PhrasalVerbsTranslatingEntity?> GetPhrasalVerbsTranslatingAsync(Guid id)
    {
        return _phrasalVerbs.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<PhrasalVerbsTranslatingEntity>> GetPhrasalVerbsTranslatingAsync(IEnumerable<Guid> ids)
    {
        return _phrasalVerbs.Where(pv => ids.Contains(pv.Id)).ToListAsync();
    }

    public Task<MissingPhrasalVerbClosedEntity?> GetMissingPhrasalVerbAsync(Guid id)
    {
        return _missingPhrasalVerb.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<MissingPhrasalVerbClosedEntity>> GetMissingPhrasalVerbAsync(IEnumerable<Guid> ids)
    {
        return _missingPhrasalVerb.Where(m => ids.Contains(m.Id)).ToListAsync();
    }

    public Task<MissingWordOrExpressionClosedEntity?> GetMissingWordOrExpressionAsync(Guid id)
    {
        return _missingWordOrExpression.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<MissingWordOrExpressionClosedEntity>> GetMissingWordOrExpressionAsync(IEnumerable<Guid> ids)
    {
        return _missingWordOrExpression.Where(m => ids.Contains(m.Id)).ToListAsync();
    }
}