using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Auth.Application.Abstractions;
using Auth.Infrastructure.Persistence;
using Auth.Infrastructure.Persistence.Repositories;
using Auth.Infrastructure.Security;

namespace Auth.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        // Banco de dados
        services.AddDbContext<AuthDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Repositórios
        services.AddScoped<IUserRepository, UserRepository>();

        // Segurança
        services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.AddScoped<IJwtProvider, JwtProvider>();

        return services;
    }
}
