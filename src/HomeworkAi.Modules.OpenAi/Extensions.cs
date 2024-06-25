using System.Reflection;
using HomeworkAi.Modules.OpenAi.Cache;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;
using HomeworkAi.Infrastructure;
using HomeworkAi.Modules.OpenAi.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI_API;

namespace HomeworkAi.Modules.OpenAi;

public static class Extensions
{
    public static IServiceCollection AddOpenAi(this IServiceCollection services, IConfiguration configuration,
        IList<Assembly> assemblies)
    {
        //TODO: add configuration object
        var apiKey = configuration["gptApiKey"];
        services.AddScoped<IOpenAIAPI>(_ => new OpenAIAPI(apiKey));
        services.AddScoped<IOpenAiExerciseService, OpenAiExerciseService>();

        services.AddSingleton<IApplicationMemoryCache, ApplicationMemoryCache>();
        services.AddTransient<IObjectSamplerService, ObjectSamplerService>();
        services.AddTransient<IPromptFormatter, PromptFormatter>();
        services.AddTransient<IExerciseResponseFactory, ExerciseResponseFactory>();
        services.AddScoped<IDeserializerService, DeserializerService>();

        services.AddInfrastructure(assemblies);
        
        return services;
    }

    public static WebApplication UseOpenAi(this WebApplication app)
    {
        app
            .AddOpenFormEndpoints()
            .AddOpenAnswerEndpoints();
        app.UseInfrastructure();

        return app;
    }
}