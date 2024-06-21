﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace HomeworkAi.Infrastructure.Commands;

internal static class Extensions
{
    internal static IServiceCollection AddCommands(this IServiceCollection services,
        IEnumerable<Assembly> assemblies)
    {
        services.AddSingleton<ICommandDispatcher, CommandDispatcher>();

        services.Scan(x => x.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}