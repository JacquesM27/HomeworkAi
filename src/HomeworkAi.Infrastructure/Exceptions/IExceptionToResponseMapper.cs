namespace HomeworkAi.Infrastructure.Exceptions;

public interface IExceptionToResponseMapper
{
    ExceptionResponse? Map(Exception exception);
}