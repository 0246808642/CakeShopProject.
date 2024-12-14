using CakeShopProject.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CakeShopProject.CrossCutting.DependencyInjection.DbConfig;

public static class DbConfigDependencyInjection
{
    public static IServiceCollection AddSqlServerDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CakeShopContext>(options =>
        {
            var vConnectionString = configuration["ConnectionString"];
            options.UseSqlServer(vConnectionString).LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();
        });

        return services;
    }

    public static void UpdateDatabase(this IServiceCollection services, IApplicationBuilder app)
    {
        var seconds = 60;
        var minutes = 20;
        var commandTimeout = seconds * minutes;

        using (var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
        {
            using (var context = serviceScope.ServiceProvider.GetService<CakeShopContext>())
            {
                context?.Database.SetCommandTimeout(commandTimeout);

                if (context is not null && context.Database.GetPendingMigrations().Any())
                    context.Database.Migrate();
                context?.Database.SetCommandTimeout(null);
            }
        }
    }
}
