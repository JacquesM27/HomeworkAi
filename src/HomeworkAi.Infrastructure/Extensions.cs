using System.Reflection;
using HomeworkAi.Infrastructure.Commands;
using HomeworkAi.Infrastructure.Exceptions;
using HomeworkAi.Infrastructure.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HomeworkAi.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IList<Assembly> assemblies)
    {
        services.AddErrorHandling();
        services.AddCommands(assemblies);
        services.AddQueries(assemblies);
        
        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseErrorHandling();

        return app;
    }
}