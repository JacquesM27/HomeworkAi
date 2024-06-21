namespace HomeworkAi.Modules.Contracts;

public sealed class SuspiciousPrompt
{
    public bool IsSuspicious { get; set; } = false;
    public List<string> Reasons { get; set; } = [];
}