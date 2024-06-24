using HomeworkAi.Modules.OpenAi.Exercises;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;
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
}