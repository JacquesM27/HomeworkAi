using HomeworkAi.Infrastructure.Exceptions;

namespace HomeworkAi.Modules.Teaching.Exceptions;

public sealed class TeacherNotFoundException(Guid id) : CustomException($"Teacher with id: '{id}' was not found.")
{
    public Guid Id => id;
}