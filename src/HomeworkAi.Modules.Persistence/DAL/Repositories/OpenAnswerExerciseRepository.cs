using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL.Repositories;

public interface IOpenAnswerExerciseRepository
{
    Task AddAsync(SentencesTranslationEntity exercise);
    Task AddAsync(SentenceWithVerbToCompleteBasedOnInfinitiveEntity exercise);
    Task AddAsync(SentenceWithVerbToCompleteEntity exercise);
    Task AddAsync(IrregularVerbsEntity exercise);
    Task AddAsync(QuestionsToTextOpenEntity exercise);
    Task AddAsync(PassiveSideOpenEntity exercise);
    Task AddAsync(ParaphrasingOpenEntity exercise);
    Task AddAsync(AnswerToQuestionOpenEntity exercise);
    Task AddAsync(ConditionalOpenEntity exercise);
    Task AddAsync(MissingPhrasalVerbOpenEntity exercise);
    Task AddAsync(MissingWordOrExpressionOpenEntity exercise);
    Task AddAsync(WordMeaningOpenEntity exercise);
    Task<SentencesTranslationEntity?> GetSentencesTranslationAsync(Guid id);

    Task<SentenceWithVerbToCompleteBasedOnInfinitiveEntity?>
        GetSentenceWithVerbToCompleteBasedOnInfinitiveAsync(Guid id);

    Task<SentenceWithVerbToCompleteEntity?> GetSentenceWithVerbToCompleteAsync(Guid id);
    Task<IrregularVerbsEntity?> GetIrregularVerbsAsync(Guid id);
    Task<QuestionsToTextOpenEntity?> GetQuestionsToTextAsync(Guid id);
    Task<PassiveSideOpenEntity?> GetPassiveSideAsync(Guid id);
    Task<ParaphrasingOpenEntity?> GetParaphrasingAsync(Guid id);
    Task<AnswerToQuestionOpenEntity?> GetAnswerToQuestionAsync(Guid id);
    Task<ConditionalOpenEntity?> GetConditionalAsync(Guid id);
    Task<MissingPhrasalVerbOpenEntity?> GetMissingPhrasalVerbAsync(Guid id);
    Task<MissingWordOrExpressionOpenEntity?> GetMissingWordOrExpressionAsync(Guid id);
    Task<WordMeaningOpenEntity?> GetWordMeaningAsync(Guid id);
}

internal sealed class OpenAnswerExerciseRepository(HomeworkDbContext dbContext) : IOpenAnswerExerciseRepository
{
    private readonly DbSet<SentencesTranslationEntity> _sentencesTranslation = dbContext.SentencesTranslationEntities;
    private readonly DbSet<SentenceWithVerbToCompleteBasedOnInfinitiveEntity> _sentenceWithVerbToCompleteBasedOnInfinitive = dbContext.SentenceWithVerbToCompleteBasedOnInfinitiveEntities;
    private readonly DbSet<SentenceWithVerbToCompleteEntity> _sentenceWithVerbToComplete = dbContext.SentenceWithVerbToCompleteEntities;
    private readonly DbSet<IrregularVerbsEntity> _irregularVerbs = dbContext.IrregularVerbsEntities;
    private readonly DbSet<QuestionsToTextOpenEntity> _questionsToText = dbContext.QuestionsToTextOpenEntities;
    private readonly DbSet<PassiveSideOpenEntity> _passiveSide = dbContext.PassiveSideOpenEntities;
    private readonly DbSet<ParaphrasingOpenEntity> _paraphrasing = dbContext.ParaphrasingOpenEntities;
    private readonly DbSet<AnswerToQuestionOpenEntity> _answerToQuestion = dbContext.AnswerToQuestionOpenEntities;
    private readonly DbSet<ConditionalOpenEntity> _conditional = dbContext.ConditionalOpenEntities;
    private readonly DbSet<MissingPhrasalVerbOpenEntity> _missingPhrasalVerb = dbContext.MissingPhrasalVerbOpenEntities;
    private readonly DbSet<MissingWordOrExpressionOpenEntity> _missingWordOrExpression = dbContext.MissingWordOrExpressionOpenEntities;
    private readonly DbSet<WordMeaningOpenEntity> _wordMeaning = dbContext.WordMeaningOpenEntities;

    public async Task AddAsync(SentencesTranslationEntity exercise)
    {
        await _sentencesTranslation.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(SentenceWithVerbToCompleteBasedOnInfinitiveEntity exercise)
    {
        await _sentenceWithVerbToCompleteBasedOnInfinitive.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(SentenceWithVerbToCompleteEntity exercise)
    {
        await _sentenceWithVerbToComplete.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(IrregularVerbsEntity exercise)
    {
        await _irregularVerbs.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(QuestionsToTextOpenEntity exercise)
    {
        await _questionsToText.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(PassiveSideOpenEntity exercise)
    {
        await _passiveSide.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(ParaphrasingOpenEntity exercise)
    {
        await _paraphrasing.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(AnswerToQuestionOpenEntity exercise)
    {
        await _answerToQuestion.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(ConditionalOpenEntity exercise)
    {
        await _conditional.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(MissingPhrasalVerbOpenEntity exercise)
    {
        await _missingPhrasalVerb.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(MissingWordOrExpressionOpenEntity exercise)
    {
        await _missingWordOrExpression.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(WordMeaningOpenEntity exercise)
    {
        await _wordMeaning.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public Task<SentencesTranslationEntity?> GetSentencesTranslationAsync(Guid id)
    {
        return _sentencesTranslation.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<SentenceWithVerbToCompleteBasedOnInfinitiveEntity?>
        GetSentenceWithVerbToCompleteBasedOnInfinitiveAsync(Guid id)
    {
        return _sentenceWithVerbToCompleteBasedOnInfinitive.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<SentenceWithVerbToCompleteEntity?> GetSentenceWithVerbToCompleteAsync(Guid id)
    {
        return _sentenceWithVerbToComplete.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<IrregularVerbsEntity?> GetIrregularVerbsAsync(Guid id)
    {
        return _irregularVerbs.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<QuestionsToTextOpenEntity?> GetQuestionsToTextAsync(Guid id)
    {
        return _questionsToText.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<PassiveSideOpenEntity?> GetPassiveSideAsync(Guid id)
    {
        return _passiveSide.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<ParaphrasingOpenEntity?> GetParaphrasingAsync(Guid id)
    {
        return _paraphrasing.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<AnswerToQuestionOpenEntity?> GetAnswerToQuestionAsync(Guid id)
    {
        return _answerToQuestion.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<ConditionalOpenEntity?> GetConditionalAsync(Guid id)
    {
        return _conditional.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<MissingPhrasalVerbOpenEntity?> GetMissingPhrasalVerbAsync(Guid id)
    {
        return _missingPhrasalVerb.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<MissingWordOrExpressionOpenEntity?> GetMissingWordOrExpressionAsync(Guid id)
    {
        return _missingWordOrExpression.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<WordMeaningOpenEntity?> GetWordMeaningAsync(Guid id)
    {
        return _wordMeaning.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}