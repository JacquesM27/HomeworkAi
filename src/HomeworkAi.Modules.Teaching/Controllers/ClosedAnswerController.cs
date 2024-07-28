using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.DAL.Entities;
using HomeworkAi.Modules.Persistence.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using HomeworkAi.Modules.Persistence.Events.Mappers;

namespace HomeworkAi.Modules.Teaching.Controllers;

[Route("closed-answer")]
[ApiController]
public class ClosedAnswerController(IClosedAnswerExerciseRepository repository) : ControllerBase
{
    //TODO: responses should be different in openai and in this controller
    [HttpGet("questions-to-text/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseResponseQuestionsToText>> GetQuestionsToTextAsync(Guid id)
    {
        var entity = await repository.GetQuestionsToTextAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .Map<ClosedAnswerExerciseResponseQuestionsToText, QuestionsToTextClosed, ClosedAnswerExerciseResponseQuestionsToTextEntity>();
        return Ok(mapped);
    }
    
    [HttpGet("passive-side/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseResponsePassiveSide>> GetPassiveSideAsync(Guid id)
    {
        var entity = await repository.GetPassiveSideAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .Map<ClosedAnswerExerciseResponsePassiveSide, PassiveSideClosed, ClosedAnswerExerciseResponsePassiveSideEntity>();
        return Ok(mapped);
    }
    
    [HttpGet("paraphrasing/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseResponseParaphrasing>> GetParaphrasingAsync(Guid id)
    {
        var entity = await repository.GetParaphrasingAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .Map<ClosedAnswerExerciseResponseParaphrasing, ParaphrasingClosed, ClosedAnswerExerciseResponseParaphrasingEntity>();
        return Ok(mapped);
    }
    
    [HttpGet("answer-to-question/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseResponseAnswerToQuestion>> GetAnswerToQuestionAsync(Guid id)
    {
        var entity = await repository.GetAnswerToQuestionAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .Map<ClosedAnswerExerciseResponseAnswerToQuestion, AnswerToQuestionClosed, ClosedAnswerExerciseResponseAnswerToQuestionEntity>();
        return Ok(mapped);
    }
    
    [HttpGet("conditional/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseResponseConditional>> GetConditionalAsync(Guid id)
    {
        var entity = await repository.GetConditionalAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .Map<ClosedAnswerExerciseResponseConditional, ConditionalClosed, ClosedAnswerExerciseResponseConditionalEntity>();
        return Ok(mapped);
    }
    
    [HttpGet("word-meaning/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseResponseWordMeaning>> GetWordMeaningAsync(Guid id)
    {
        var entity = await repository.GetWordMeaningAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .Map<ClosedAnswerExerciseResponseWordMeaning, WordMeaningClosed, ClosedAnswerExerciseResponseWordMeaningEntity>();
        return Ok(mapped);
    }
    
    [HttpGet("phrasal-verbs-translating/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseResponsePhrasalVerbsTranslating>> GetPhrasalVerbsTranslatingAsync(Guid id)
    {
        var entity = await repository.GetPhrasalVerbsTranslatingAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .Map<ClosedAnswerExerciseResponsePhrasalVerbsTranslating, PhrasalVerbsTranslating, ClosedAnswerExerciseResponsePhrasalVerbsTranslatingEntity>();
        return Ok(mapped);
    }
    
    [HttpGet("missing-phrasal-verb/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseResponseMissingPhrasalVerb>> GetMissingPhrasalVerbAsync(Guid id)
    {
        var entity = await repository.GetMissingPhrasalVerbAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .Map<ClosedAnswerExerciseResponseMissingPhrasalVerb, MissingPhrasalVerbClosed, ClosedAnswerExerciseResponseMissingPhrasalVerbEntity>();
        return Ok(mapped);
    }
    
    [HttpGet("missing-word-or-expression/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseResponseMissingWordOrExpression>> GetMissingWordOrExpressionAsync(Guid id)
    {
        var entity = await repository.GetMissingWordOrExpressionAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .Map<ClosedAnswerExerciseResponseMissingWordOrExpression, MissingWordOrExpressionClosed, ClosedAnswerExerciseResponseMissingWordOrExpressionEntity>();
        return Ok(mapped);
    }
}