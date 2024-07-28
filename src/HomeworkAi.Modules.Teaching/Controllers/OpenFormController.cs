using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.DAL.Entities;
using HomeworkAi.Modules.Persistence.DAL.Repositories;
using HomeworkAi.Modules.Persistence.Events.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkAi.Modules.Teaching.Controllers;

[Route("open-form")]
[ApiController]
public class OpenFormController(IOpenFormExerciseRepository repository) : ControllerBase
{
    //TODO: responses should be different in openai and in this controller
    [HttpGet("mail/{id:guid}")]
    public async Task<ActionResult<OpenFormExerciseResponseMail?>> GetMailAsync(Guid id)
    {
        var mailEntity = await repository.GetMailAsync(id);

        if (mailEntity == null) return NotFound();

        var mapped = mailEntity.Map<OpenFormExerciseResponseMail, Mail, OpenFormExerciseMailEntity>();
        return Ok(mapped);
    }

    [HttpGet("essay/{id:guid}")]
    public async Task<ActionResult<OpenFormExerciseResponseEssay?>> GetEssayAsync(Guid id)
    {
        var essayEntity = await repository.GetEssayAsync(id);

        if (essayEntity == null) return NotFound();

        var mapped = essayEntity.Map<OpenFormExerciseResponseEssay, Essay, OpenFormExerciseEssayEntity>();
        return Ok(mapped);
    }

    [HttpGet("summary-of-text/{id:guid}")]
    public async Task<ActionResult<OpenFormExerciseResponseSummaryOfText?>> GetSummaryOfTextAsync(Guid id)
    {
        var summaryOfTextEntity = await repository.GetSummaryOfTextAsync(id);

        if (summaryOfTextEntity == null) return NotFound();

        var mapped = summaryOfTextEntity
            .Map<OpenFormExerciseResponseSummaryOfText, SummaryOfText, OpenFormExerciseSummaryOfTextEntity>();
        return Ok(mapped);
    }
}