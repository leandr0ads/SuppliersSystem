using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Suppliers.Application.Abstractions;
using Suppliers.Infrastructure.Persistence;
using Suppliers.Infrastructure.Persistence.Repositories;
using Suppliers.Infrastructure.Security;

namespace Suppliers.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Banco de dados
        services.AddDbContext<SuppliersDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Repositórios
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IDeliveryRepository, DeliveryRepository>();

        // JWT
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));

        return services;
    }
}
