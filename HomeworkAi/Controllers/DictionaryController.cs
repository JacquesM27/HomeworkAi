using System.Net;
using HomeworkAi.Modules.OpenAi.Cache;
using HomeworkAi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkAi.Controllers;

[ApiController]
[Route("[controller]")]
public class DictionaryController(IApplicationMemoryCache cache) : ControllerBase
{
    [HttpGet("/closed-answer")]
    [ProducesResponse(HttpStatusCode.OK, typeof(IEnumerable<string>))]
    public ActionResult<IEnumerable<string>> GetClosedAnswerExercises()
    {
        return Ok(cache.GetClosedAnswerExercises());
    }

    [HttpGet("/open-answer")]
    [ProducesResponse(HttpStatusCode.OK, typeof(IEnumerable<string>))]
    public ActionResult<IEnumerable<string>> GetOpenAnswerExercises()
    {
        return Ok(cache.GetOpenAnswerExercises());
    }

    [HttpGet("/open-form")]
    [ProducesResponse(HttpStatusCode.OK, typeof(IEnumerable<string>))]
    public ActionResult<IEnumerable<string>> GetOpenFormExercises()
    {
        return Ok(cache.GetOpenFormExercises());
    }

    [HttpGet("/languages")]
    [ProducesResponse(HttpStatusCode.OK, typeof(IEnumerable<string>))]
    public ActionResult<IEnumerable<string>> GetLanguages()
    {
        return Ok(cache.GetLanguages());
    }
}