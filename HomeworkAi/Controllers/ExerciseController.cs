﻿using System.Net;
using HomeworkAi.Modules.OpenAi.Exercises;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;
using HomeworkAi.Infrastructure.Attributes;
using HomeworkAi.Modules.Contracts.Exercises;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkAi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExerciseController(IOpenAiExerciseService openAiExerciseService) : ControllerBase
{
    [HttpPost("/open-answer")]
    [ProducesResponse(HttpStatusCode.OK, typeof(ExerciseResponseOld))]
    public async Task<ActionResult<ExerciseResponseOld>> OpenAnswer(OpenAnswerExercisePromptOld promptOld)
    {
        var response = await openAiExerciseService.PromptForExercise(promptOld);
        return Ok(response);
    }
    
    [HttpPost("/closed-answer")]
    [ProducesResponse(HttpStatusCode.OK, typeof(ExerciseResponseOld))]
    public async Task<ActionResult<ExerciseResponseOld>> ClosedAnswer(ClosedAnswerExercisePromptOld promptOld)
    {
        var response = await openAiExerciseService.PromptForExercise(promptOld);
        return Ok(response);
    }
}