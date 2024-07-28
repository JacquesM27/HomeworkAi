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
}