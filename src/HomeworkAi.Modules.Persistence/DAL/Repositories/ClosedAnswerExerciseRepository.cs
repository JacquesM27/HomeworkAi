using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL.Repositories;

public interface IClosedAnswerExerciseRepository
{
    Task AddAsync(ClosedAnswerExerciseResponseQuestionsToTextEntity exercise);
    Task AddAsync(ClosedAnswerExerciseResponsePassiveSideEntity exercise);
    Task AddAsync(ClosedAnswerExerciseResponseParaphrasingEntity exercise);
    Task AddAsync(ClosedAnswerExerciseResponseAnswerToQuestionEntity exercise);
    Task AddAsync(ClosedAnswerExerciseResponseConditionalEntity exercise);
    Task AddAsync(ClosedAnswerExerciseResponseWordMeaningEntity exercise);
    Task AddAsync(ClosedAnswerExerciseResponsePhrasalVerbsTranslatingEntity exercise);
    Task AddAsync(ClosedAnswerExerciseResponseMissingPhrasalVerbEntity exercise);
    Task AddAsync(ClosedAnswerExerciseResponseMissingWordOrExpressionEntity exercise);

    Task<ClosedAnswerExerciseResponseQuestionsToTextEntity?> GetQuestionsToTextAsync(Guid id);
    Task<ClosedAnswerExerciseResponsePassiveSideEntity?> GetPassiveSideAsync(Guid id);
    Task<ClosedAnswerExerciseResponseParaphrasingEntity?> GetParaphrasingAsync(Guid id);
    Task<ClosedAnswerExerciseResponseAnswerToQuestionEntity?> GetAnswerToQuestionAsync(Guid id);
    Task<ClosedAnswerExerciseResponseConditionalEntity?> GetConditionalAsync(Guid id);
    Task<ClosedAnswerExerciseResponseWordMeaningEntity?> GetWordMeaningAsync(Guid id);
    Task<ClosedAnswerExerciseResponsePhrasalVerbsTranslatingEntity?> GetPhrasalVerbsTranslatingAsync(Guid id);
    Task<ClosedAnswerExerciseResponseMissingPhrasalVerbEntity?> GetMissingPhrasalVerbAsync(Guid id);
    Task<ClosedAnswerExerciseResponseMissingWordOrExpressionEntity?> GetMissingWordOrExpressionAsync(Guid id);
}

internal sealed class ClosedAnswerExerciseRepository(HomeworkDbContext dbContext) : IClosedAnswerExerciseRepository
{
    private readonly DbSet<ClosedAnswerExerciseResponseQuestionsToTextEntity> _questionsToText =
        dbContext.ClosedAnswerExerciseResponseQuestionsToTextEntities;

    private readonly DbSet<ClosedAnswerExerciseResponsePassiveSideEntity> _passiveSide =
        dbContext.ClosedAnswerExerciseResponsePassiveSideEntities;

    private readonly DbSet<ClosedAnswerExerciseResponseParaphrasingEntity> _paraphrasing =
        dbContext.ClosedAnswerExerciseResponseParaphrasingEntities;

    private readonly DbSet<ClosedAnswerExerciseResponseAnswerToQuestionEntity> _answerToQuestion =
        dbContext.ClosedAnswerExerciseResponseAnswerToQuestionEntities;

    private readonly DbSet<ClosedAnswerExerciseResponseConditionalEntity> _conditional =
        dbContext.ClosedAnswerExerciseResponseConditionalEntities;

    private readonly DbSet<ClosedAnswerExerciseResponseWordMeaningEntity> _wordMeaning =
        dbContext.ClosedAnswerExerciseResponseWordMeaningEntities;

    private readonly DbSet<ClosedAnswerExerciseResponsePhrasalVerbsTranslatingEntity> _phrasalVerbs =
        dbContext.ClosedAnswerExerciseResponsePhrasalVerbsTranslatingEntities;

    private readonly DbSet<ClosedAnswerExerciseResponseMissingPhrasalVerbEntity> _missingPhrasalVerb =
        dbContext.ClosedAnswerExerciseResponseMissingPhrasalVerbEntities;

    private readonly DbSet<ClosedAnswerExerciseResponseMissingWordOrExpressionEntity> _missingWordOrExpression =
        dbContext.ClosedAnswerExerciseResponseMissingWordOrExpressionEntities;

    public async Task AddAsync(ClosedAnswerExerciseResponseQuestionsToTextEntity exercise)
    {
        await _questionsToText.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(ClosedAnswerExerciseResponsePassiveSideEntity exercise)
    {
        await _passiveSide.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(ClosedAnswerExerciseResponseParaphrasingEntity exercise)
    {
        await _paraphrasing.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(ClosedAnswerExerciseResponseAnswerToQuestionEntity exercise)
    {
        await _answerToQuestion.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(ClosedAnswerExerciseResponseConditionalEntity exercise)
    {
        await _conditional.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(ClosedAnswerExerciseResponseWordMeaningEntity exercise)
    {
        await _wordMeaning.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(ClosedAnswerExerciseResponsePhrasalVerbsTranslatingEntity exercise)
    {
        await _phrasalVerbs.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(ClosedAnswerExerciseResponseMissingPhrasalVerbEntity exercise)
    {
        await _missingPhrasalVerb.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddAsync(ClosedAnswerExerciseResponseMissingWordOrExpressionEntity exercise)
    {
        await _missingWordOrExpression.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
    }

    public Task<ClosedAnswerExerciseResponseQuestionsToTextEntity?> GetQuestionsToTextAsync(Guid id)
    {
        return _questionsToText.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<ClosedAnswerExerciseResponsePassiveSideEntity?> GetPassiveSideAsync(Guid id)
    {
        return _passiveSide.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<ClosedAnswerExerciseResponseParaphrasingEntity?> GetParaphrasingAsync(Guid id)
    {
        return _paraphrasing.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<ClosedAnswerExerciseResponseAnswerToQuestionEntity?> GetAnswerToQuestionAsync(Guid id)
    {
        return _answerToQuestion.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<ClosedAnswerExerciseResponseConditionalEntity?> GetConditionalAsync(Guid id)
    {
        return _conditional.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<ClosedAnswerExerciseResponseWordMeaningEntity?> GetWordMeaningAsync(Guid id)
    {
        return _wordMeaning.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<ClosedAnswerExerciseResponsePhrasalVerbsTranslatingEntity?> GetPhrasalVerbsTranslatingAsync(Guid id)
    {
        return _phrasalVerbs.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<ClosedAnswerExerciseResponseMissingPhrasalVerbEntity?> GetMissingPhrasalVerbAsync(Guid id)
    {
        return _missingPhrasalVerb.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<ClosedAnswerExerciseResponseMissingWordOrExpressionEntity?> GetMissingWordOrExpressionAsync(Guid id)
    {
        return _missingWordOrExpression.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}