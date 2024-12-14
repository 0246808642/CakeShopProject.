using CakeShopProject.Data.Repository;
using CakeShopProject.Domain.Interface.Repository;
using CakeShopProject.Domain.Interface.Service;
using Microsoft.Extensions.DependencyInjection;



namespace CakeShopProject.CrossCutting.DependencyInjection.Repository;

public static class RepositoryDependencyInjection
{
    public static IServiceCollection AddSqlRepositoryDependecy(this IServiceCollection services)
    {
        return new ServiceCollection()
            .AddScoped<ICityRepository, CityRepository>()
            .AddScoped<IClientRepository, ClientRepository>()
            .AddScoped<IOrdersRepository, OrdersRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IStateRepository, StateRepository>();
    }

}
