using HomeworkAi.Infrastructure.Exceptions;

namespace HomeworkAi.Modules.Teaching.Exceptions;

public sealed class ClassNotFoundException(Guid id) : CustomException($"Class with id: '{id}' was not found")
{
    public Guid Id => id;
}