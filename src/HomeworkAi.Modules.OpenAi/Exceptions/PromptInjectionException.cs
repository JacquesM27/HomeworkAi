using HomeworkAi.Infrastructure.Exceptions;

namespace HomeworkAi.Modules.OpenAi.Exceptions;

public sealed class PromptInjectionException()
    : CustomException($"Prompt contains an invalid injection value."); 