namespace HomeworkAi.Infrastructure.Settings;

public sealed class MsSqlSettings
{
    public const string SectionName = "mssql";
    public string ConnectionString { get; set; } = string.Empty;
}