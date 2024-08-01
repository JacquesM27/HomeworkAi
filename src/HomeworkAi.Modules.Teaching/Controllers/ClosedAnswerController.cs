using HomeworkAi.Modules.Contracts.DTOs.Complex;
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
    [HttpGet("questions-to-text/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseQuestionsToTextDto?>> GetQuestionsToTextAsync(Guid id)
    {
        var entity = await repository.GetQuestionsToTextAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<ClosedAnswerExerciseQuestionsToTextDto, QuestionsToTextClosed, QuestionsToTextClosedEntity>();
        return Ok(mapped);
    }

    [HttpGet("passive-side/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExercisePassiveSideDto?>> GetPassiveSideAsync(Guid id)
    {
        var entity = await repository.GetPassiveSideAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<ClosedAnswerExercisePassiveSideDto, PassiveSideClosed, PassiveSideClosedEntity>();
        return Ok(mapped);
    }

    [HttpGet("paraphrasing/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseParaphrasingDto?>> GetParaphrasingAsync(Guid id)
    {
        var entity = await repository.GetParaphrasingAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<ClosedAnswerExerciseParaphrasingDto, ParaphrasingClosed, ParaphrasingClosedEntity>();
        return Ok(mapped);
    }

    [HttpGet("answer-to-question/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseAnswerToQuestionDto?>> GetAnswerToQuestionAsync(Guid id)
    {
        var entity = await repository.GetAnswerToQuestionAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<ClosedAnswerExerciseAnswerToQuestionDto, AnswerToQuestionClosed, AnswerToQuestionClosedEntity>();
        return Ok(mapped);
    }

    [HttpGet("conditional/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseConditionalDto?>> GetConditionalAsync(Guid id)
    {
        var entity = await repository.GetConditionalAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<ClosedAnswerExerciseConditionalDto, ConditionalClosed, ConditionalClosedEntity>();
        return Ok(mapped);
    }

    [HttpGet("word-meaning/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseWordMeaningDto?>> GetWordMeaningAsync(Guid id)
    {
        var entity = await repository.GetWordMeaningAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<ClosedAnswerExerciseWordMeaningDto, WordMeaningClosed, WordMeaningClosedEntity>();
        return Ok(mapped);
    }

    [HttpGet("phrasal-verbs-translating/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExercisePhrasalVerbsTranslatingDto?>>
        GetPhrasalVerbsTranslatingAsync(Guid id)
    {
        var entity = await repository.GetPhrasalVerbsTranslatingAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<ClosedAnswerExercisePhrasalVerbsTranslatingDto, PhrasalVerbsTranslating,
                PhrasalVerbsTranslatingEntity>();
        return Ok(mapped);
    }

    [HttpGet("missing-phrasal-verb/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseMissingPhrasalVerbDto?>> GetMissingPhrasalVerbAsync(Guid id)
    {
        var entity = await repository.GetMissingPhrasalVerbAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<ClosedAnswerExerciseMissingPhrasalVerbDto, MissingPhrasalVerbClosed,
                MissingPhrasalVerbClosedEntity>();
        return Ok(mapped);
    }

    [HttpGet("missing-word-or-expression/{id:guid}")]
    public async Task<ActionResult<ClosedAnswerExerciseMissingWordOrExpressionDto?>>
        GetMissingWordOrExpressionAsync(Guid id)
    {
        var entity = await repository.GetMissingWordOrExpressionAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<ClosedAnswerExerciseMissingWordOrExpressionDto, MissingWordOrExpressionClosed,
                MissingWordOrExpressionClosedEntity>();
        return Ok(mapped);
    }
}