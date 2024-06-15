using HomeworkAi.Infrastructure.Exceptions;

namespace HomeworkAi.Core.Exceptions;

public sealed class InvalidExerciseTypeException(string type)
    : CustomException($"Exercise type: '{type}' is not valid."); 