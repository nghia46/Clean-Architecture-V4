using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infastructure.Data;
using CleanArchitecture.Infastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Add your infrastructure services here
            services.AddScoped<IProductRepository, ProductRepository>();
            // Add DbContext
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgresDb"));
            });
            return services;
        }
    }
}