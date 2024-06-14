using System.Net;
using HomeworkAi.Core.Attributes;
using HomeworkAi.Core.DTO.Exercises;
using HomeworkAi.OpenAi;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkAi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExerciseController(IOpenAiService openAiService) : ControllerBase
{
    [HttpPost("/open-answer")]
    [ProducesResponse(HttpStatusCode.OK, typeof(ExerciseResponse))]
    public async Task<ActionResult<ExerciseResponse>> OpenAnswer(OpenAnswerExercisePrompt prompt)
    {
        var response = await openAiService.ExercisePromptSentence(prompt);
        return Ok(response);
    }
    
    [HttpPost("/closed-answer")]
    [ProducesResponse(HttpStatusCode.OK, typeof(ExerciseResponse))]
    public async Task<ActionResult<ExerciseResponse>> ClosedAnswer(ClosedAnswerExercisePrompt prompt)
    {
        var response = await openAiService.ExercisePromptSentence(prompt);
        return Ok(response);
    }
    
    [HttpPost("/open-form")]
    [ProducesResponse(HttpStatusCode.OK, typeof(ExerciseResponse))]
    public async Task<ActionResult<ExerciseResponse>> OpenForm(OpenFormExercisePrompt prompt)
    {
        var response = await openAiService.ExercisePromptSentence(prompt);
        return Ok(response);
    }
}