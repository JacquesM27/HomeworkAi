using HomeworkAi.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeworkAi.Modules.Persistence.DAL;

internal static class Extensions
{
    internal static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        var pgSettings = configuration.GetConfiguredOptions<PostgreSqlSettings>(PostgreSqlSettings.SectionName);

        services.AddDbContext<HomeworkDbContext>(x => x.UseNpgsql(pgSettings.ConnectionString));

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        return services;
    }
}