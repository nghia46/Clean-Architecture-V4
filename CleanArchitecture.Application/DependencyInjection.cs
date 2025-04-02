using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.Application.Utils;

namespace CleanArchitecture.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Register MediatR
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        // Kafka 
        services.AddSingleton(new ProducerConfig{
            BootstrapServers = configuration["Kafka:BootstrapServers"],
            SocketTimeoutMs = 10000,
            MessageTimeoutMs = 10000,
        });

        // Register KafkaHelper
        services.AddScoped(typeof(IKafkaHelper<>), typeof(KafkaHelper<>));

        return services;
    }
}
