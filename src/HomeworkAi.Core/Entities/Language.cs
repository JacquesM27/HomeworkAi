namespace HomeworkAi.Core.Entities;

public class Language
{
    public string Value { get; }
    
    public const string English = nameof(English);
    public const string Polish = nameof(Polish);
    public const string German = nameof(German);
    public const string Italian = nameof(Italian);

    public static readonly string[] Languages = [ English, Polish, German, Italian ];

    public Language(string value)
    {
        if (!Languages.Contains(value))
            throw new ArgumentException($"Language must be selected from the range: {string.Join(",", Languages)}");
        
        Value = value;
    }
}