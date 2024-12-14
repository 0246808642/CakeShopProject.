using CakeShopProject.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CakeShopProject.CrossCutting.DependencyInjection.Validation;

public static class ValidatorsDependencyInjection
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<City>, CityValidator>();
        services.AddScoped<IValidator<Client>, ClientValidator>();
        services.AddScoped<IValidator<Orders>, OrdersValidator>();
        services.AddScoped<IValidator<Product>, ProductValidator>();
        services.AddScoped<IValidator<State>, StateValidator>();
        return services;
    }
}
