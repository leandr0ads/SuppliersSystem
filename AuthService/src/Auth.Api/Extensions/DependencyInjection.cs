using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.Load("Auth.Application")));

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.Load("Auth.Application"));

        return services;
    }
}
