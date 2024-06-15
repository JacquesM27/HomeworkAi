using System.Net;

namespace HomeworkAi.Infrastructure.Exceptions;

public sealed record ExceptionResponse(object Response, HttpStatusCode StatusCode);