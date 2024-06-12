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
    
    [HttpGet("/gpt")]
    public async Task<ActionResult> HelloGpt(string text)
    {
        if (String.IsNullOrEmpty(text))
        {
            return BadRequest();
        }
        try
        {
            var response = await openAiService.CompleteSentence(text);
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