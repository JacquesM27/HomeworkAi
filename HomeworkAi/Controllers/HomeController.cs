using HomeworkAi.Core.Exercises;
using HomeworkAi.Core.Services.OpenAi;
using HomeworkAi.Modules.Contracts.Exercises;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkAi.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController(IOpenAiExerciseService openAiExerciseService) : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Hello()
    {
        return Ok("test");
    }
    
    [HttpPost("/gpt")]
    public async Task<ActionResult> HelloGpt(OpenAnswerExercisePromptOld text)
    {
        try
        {
            //TODO: add normal methods and prompt injection validation
            var response = await openAiExerciseService.PromptForExercise(text);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("test")]
    public async Task<ActionResult> Hello(OpenAnswerExercisePromptOld promptOld)
    {
        return Ok();
    }
}