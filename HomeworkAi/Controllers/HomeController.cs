using HomeworkAi.Core.DTO.Exercises;
using HomeworkAi.OpenAi;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkAi.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController(IOpenAiService openAiService) : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Hello()
    {
        return Ok("test");
    }
    
    [HttpPost("/gpt")]
    public async Task<ActionResult> HelloGpt(OpenAnswerExercisePrompt text)
    {
        try
        {
            //TODO: add normal methods and prompt injection validation
            var response = await openAiService.ExercisePromptSentence(text);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("test")]
    public async Task<ActionResult> Hello(OpenAnswerExercisePrompt prompt)
    {
        return Ok();
    }
}