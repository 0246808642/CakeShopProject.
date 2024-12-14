using CakeShopProject.Data.Repository;
using CakeShopProject.Domain.Interface.Repository;
using CakeShopProject.Domain.Interface.Service;
using CakeShopProject.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CakeShopProject.CrossCutting.DependencyInjection.Service;

public static class ServiceDependencyInjection
{
    public static IServiceCollection AddSqlServiceDependecy(this IServiceCollection services)
    {
        return new ServiceCollection()
            .AddScoped<ICityService, CityService>()
            .AddScoped<IClientService, ClientService>()
            .AddScoped<IOrdersService, OrdersService>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<IStateService, StateService>();
    }

}
