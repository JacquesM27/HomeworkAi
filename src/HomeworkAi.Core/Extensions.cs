using HomeworkAi.Core.Cache;
using HomeworkAi.Core.Services;
using HomeworkAi.Core.Services.OpenAi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI_API;

namespace HomeworkAi.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        //TODO: add configuration object
        var apiKey = configuration["gptApiKey"];
        services.AddScoped<IOpenAIAPI>(_ => new OpenAIAPI(apiKey));
        services.AddScoped<IOpenAiService, OpenAiService>();


        services.AddSingleton<IApplicationMemoryCache, ApplicationMemoryCache>();
        services.AddTransient<IObjectSamplerService, ObjectSamplerService>();
        services.AddTransient<IPromptFormatter, PromptFormatter>();
        services.AddScoped<IExerciseFormatService, ExerciseFormatService>();

        return services;
    }
}