using System.Net;
using HomeworkAi.Core.Cache;
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
        => Ok(cache.GetClosedAnswerExercises());
    
    [HttpGet("/open-answer")]
    [ProducesResponse(HttpStatusCode.OK, typeof(IEnumerable<string>))]
    public ActionResult<IEnumerable<string>> GetOpenAnswerExercises() 
        => Ok(cache.GetOpenAnswerExercises());
    
    [HttpGet("/open-form")]
    [ProducesResponse(HttpStatusCode.OK, typeof(IEnumerable<string>))]
    public ActionResult<IEnumerable<string>> GetOpenFormExercises() 
        => Ok(cache.GetOpenFormExercises());
    
    [HttpGet("/languages")]
    [ProducesResponse(HttpStatusCode.OK, typeof(IEnumerable<string>))]
    public ActionResult<IEnumerable<string>> GetLanguages() 
        => Ok(cache.GetLanguages());
}