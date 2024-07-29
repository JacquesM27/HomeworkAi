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
    Task<PassiveSideClosedEntity?> GetPassiveSideAsync(Guid id);
    Task<ParaphrasingClosedEntity?> GetParaphrasingAsync(Guid id);
    Task<AnswerToQuestionClosedEntity?> GetAnswerToQuestionAsync(Guid id);
    Task<ConditionalClosedEntity?> GetConditionalAsync(Guid id);
    Task<WordMeaningClosedEntity?> GetWordMeaningAsync(Guid id);
    Task<PhrasalVerbsTranslatingEntity?> GetPhrasalVerbsTranslatingAsync(Guid id);
    Task<MissingPhrasalVerbClosedEntity?> GetMissingPhrasalVerbAsync(Guid id);
    Task<MissingWordOrExpressionClosedEntity?> GetMissingWordOrExpressionAsync(Guid id);
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

    public Task<PassiveSideClosedEntity?> GetPassiveSideAsync(Guid id)
    {
        return _passiveSide.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<ParaphrasingClosedEntity?> GetParaphrasingAsync(Guid id)
    {
        return _paraphrasing.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<AnswerToQuestionClosedEntity?> GetAnswerToQuestionAsync(Guid id)
    {
        return _answerToQuestion.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<ConditionalClosedEntity?> GetConditionalAsync(Guid id)
    {
        return _conditional.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<WordMeaningClosedEntity?> GetWordMeaningAsync(Guid id)
    {
        return _wordMeaning.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<PhrasalVerbsTranslatingEntity?> GetPhrasalVerbsTranslatingAsync(Guid id)
    {
        return _phrasalVerbs.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<MissingPhrasalVerbClosedEntity?> GetMissingPhrasalVerbAsync(Guid id)
    {
        return _missingPhrasalVerb.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<MissingWordOrExpressionClosedEntity?> GetMissingWordOrExpressionAsync(Guid id)
    {
        return _missingWordOrExpression.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}