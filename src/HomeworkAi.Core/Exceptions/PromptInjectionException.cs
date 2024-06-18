using HomeworkAi.Infrastructure.Exceptions;

namespace HomeworkAi.Core.Exceptions;

public sealed class PromptInjectionException()
    : CustomException($"Prompt contains an invalid injection value."); 