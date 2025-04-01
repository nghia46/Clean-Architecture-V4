using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        // Register MediatR
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        return services;
    }
}
