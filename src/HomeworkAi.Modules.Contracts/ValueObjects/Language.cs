namespace HomeworkAi.Modules.Contracts.ValueObjects;

public sealed class Language
{
    public string Value { get; }

    public const string English = nameof(English);
    public const string Polish = nameof(Polish);
    public const string German = nameof(German);
    public const string Italian = nameof(Italian);

    public static readonly string[] Languages = [English, Polish, German, Italian];

    public Language(string value)
    {
        var language = Languages.First(lang => lang.Equals(value, StringComparison.OrdinalIgnoreCase));
        if (string.IsNullOrWhiteSpace(language))
            throw new ArgumentException($"Language must be selected from the range: {string.Join(",", Languages)}");

        Value = language;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator Language(string language)
    {
        return new Language(language);
    }

    public static implicit operator string(Language language)
    {
        return language.Value;
    }
}