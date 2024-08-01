using HomeworkAi.Modules.Contracts.DTOs.Complex;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.DAL.Entities;
using HomeworkAi.Modules.Persistence.DAL.Repositories;
using HomeworkAi.Modules.Persistence.Events.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkAi.Modules.Teaching.Controllers;

[Route("open-answer")]
[ApiController]
public class OpenAnswerController(IOpenAnswerExerciseRepository repository) : ControllerBase
{
    [HttpGet("answer-to-question/{id:guid}")]
    public async Task<ActionResult<OpenAnswerExerciseAnswerToQuestionDto?>> GetAnswerToQuestionAsync(Guid id)
    {
        var entity = await repository.GetAnswerToQuestionAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<OpenAnswerExerciseAnswerToQuestionDto, AnswerToQuestionOpen, AnswerToQuestionOpenEntity>();

        return Ok(mapped);
    }

    [HttpGet("conditional/{id:guid}")]
    public async Task<ActionResult<OpenAnswerExerciseConditionalDto?>> GetConditionalAsync(Guid id)
    {
        var entity = await repository.GetConditionalAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<OpenAnswerExerciseConditionalDto, ConditionalOpen, ConditionalOpenEntity>();

        return Ok(mapped);
    }

    [HttpGet("irregular-verbs/{id:guid}")]
    public async Task<ActionResult<OpenAnswerExerciseIrregularVerbsDto?>> GetIrregularVerbsAsync(Guid id)
    {
        var entity = await repository.GetIrregularVerbsAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<OpenAnswerExerciseIrregularVerbsDto, IrregularVerbs, IrregularVerbsEntity>();

        return Ok(mapped);
    }

    [HttpGet("missing-phrasal-verb/{id:guid}")]
    public async Task<ActionResult<OpenAnswerExerciseMissingPhrasalVerbDto?>> GetMissingPhrasalVerbAsync(Guid id)
    {
        var entity = await repository.GetMissingPhrasalVerbAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<OpenAnswerExerciseMissingPhrasalVerbDto, MissingPhrasalVerbOpen, MissingPhrasalVerbOpenEntity>();

        return Ok(mapped);
    }

    [HttpGet("missing-word-or-expression/{id:guid}")]
    public async Task<ActionResult<OpenAnswerExerciseMissingWordOrExpressionDto?>> GetMissingWordOrExpressionAsync(Guid id)
    {
        var entity = await repository.GetMissingWordOrExpressionAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<OpenAnswerExerciseMissingWordOrExpressionDto, MissingWordOrExpressionOpen,
                MissingWordOrExpressionOpenEntity>();

        return Ok(mapped);
    }

    [HttpGet("paraphrasing/{id:guid}")]
    public async Task<ActionResult<OpenAnswerExerciseParaphrasingDto?>> GetParaphrasingAsync(Guid id)
    {
        var entity = await repository.GetParaphrasingAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<OpenAnswerExerciseParaphrasingDto, ParaphrasingOpen, ParaphrasingOpenEntity>();

        return Ok(mapped);
    }

    [HttpGet("passive-side/{id:guid}")]
    public async Task<ActionResult<OpenAnswerExercisePassiveSideDto?>> GetPassiveSideAsync(Guid id)
    {
        var entity = await repository.GetPassiveSideAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<OpenAnswerExercisePassiveSideDto, PassiveSideOpen, PassiveSideOpenEntity>();

        return Ok(mapped);
    }

    [HttpGet("questions-to-text/{id:guid}")]
    public async Task<ActionResult<OpenAnswerExerciseQuestionsToTextDto?>> GetQuestionsToTextAsync(Guid id)
    {
        var entity = await repository.GetQuestionsToTextAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<OpenAnswerExerciseQuestionsToTextDto, QuestionsToTextOpen, QuestionsToTextOpenEntity>();

        return Ok(mapped);
    }

    [HttpGet("sentences-translation/{id:guid}")]
    public async Task<ActionResult<OpenAnswerExerciseSentencesTranslationDto?>> GetSentencesTranslationAsync(Guid id)
    {
        var entity = await repository.GetSentencesTranslationAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<OpenAnswerExerciseSentencesTranslationDto, SentencesTranslation, SentencesTranslationEntity>();

        return Ok(mapped);
    }

    [HttpGet("sentences-with-verb-to-complete-based-on-infinitive/{id:guid}")]
    public async Task<ActionResult<OpenAnswerExerciseSentenceWithVerbToCompleteBasedOnInfinitiveDto?>> GetSentenceWithVerbToCompleteBasedOnInfinitiveAsync(Guid id)
    {
        var entity = await repository.GetSentenceWithVerbToCompleteBasedOnInfinitiveAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<OpenAnswerExerciseSentenceWithVerbToCompleteBasedOnInfinitiveDto,
                SentenceWithVerbToCompleteBasedOnInfinitive, SentenceWithVerbToCompleteBasedOnInfinitiveEntity>();

        return Ok(mapped);
    }

    [HttpGet("word-meaning/{id:guid}")]
    public async Task<ActionResult<OpenAnswerExerciseWordMeaningDto?>> GetWordMeaningAsync(Guid id)
    {
        var entity = await repository.GetWordMeaningAsync(id);

        if (entity is null) return NotFound();

        var mapped = entity
            .MapToDto<OpenAnswerExerciseWordMeaningDto, WordMeaningOpen, WordMeaningOpenEntity>();

        return Ok(mapped);
    }
}