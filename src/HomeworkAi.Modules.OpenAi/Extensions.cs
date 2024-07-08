using HomeworkAi.Modules.OpenAi.Cache;
using HomeworkAi.Modules.OpenAi.Services;
using HomeworkAi.Modules.OpenAi.Services.OpenAi;
using HomeworkAi.Infrastructure.Settings;
using HomeworkAi.Modules.OpenAi.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI_API;

namespace HomeworkAi.Modules.OpenAi;

public static class Extensions
{
    public static IServiceCollection AddOpenAi(this IServiceCollection services, IConfiguration configuration)
    {
        var openAiSettings = configuration.GetConfiguredOptions<OpenAiSettings>(OpenAiSettings.SectionName);
        services.AddScoped<IOpenAIAPI>(_ => new OpenAIAPI(openAiSettings.ApiKey));
        services.AddScoped<IOpenAiExerciseService, OpenAiExerciseService>();

        services.AddSingleton<IApplicationMemoryCache, ApplicationMemoryCache>();
        services.AddTransient<IObjectSamplerService, ObjectSamplerService>();
        services.AddTransient<IPromptFormatter, PromptFormatter>();
        services.AddScoped<IDeserializerService, DeserializerService>();

        return services;
    }

    public static WebApplication UseOpenAi(this WebApplication app)
    {
        app
            .AddOpenFormEndpoints()
            .AddOpenAnswerEndpoints()
            .AddClosedAnswerEndpoints();

        return app;
    }
}