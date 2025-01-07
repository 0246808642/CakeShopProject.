using CakeShopProject.CrossCutting.DependencyInjection.DbConfig;
using CakeShopProject.CrossCutting.DependencyInjection.Repository;
using CakeShopProject.CrossCutting.DependencyInjection.Service;
using CakeShopProject.CrossCutting.DependencyInjection.AutoMapper.Config;
using CakeShopProject.CrossCutting.DependencyInjection.Validation;
using Serilog;
using Microsoft.OpenApi.Models;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Ioc
builder.Services.AddSqlServerDependency(builder.Configuration);
builder.Services.AddSqlRepositoryDependecy();
builder.Services.AddSqlServiceDependecy();
builder.Services.AddMapperConfiguration();
builder.Services.AddValidators();
#endregion
Log.Information("WebApi - Atualizando a base de dados do sistema");

#region Configure TimeZoneInfo
var brazilTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
builder.Services.AddSingleton(brazilTimeZone);

// Configurar cultura
var defaultDateCulture = "pt-BR";
var ci = new CultureInfo(defaultDateCulture)
{
    NumberFormat = { CurrencySymbol = "R$" },
    DateTimeFormat =
    {
        ShortDatePattern = "dd/MM/yyyy",
        LongDatePattern = "dddd, d' de 'MMMM' de 'yyyy",
        ShortTimePattern = "HH:mm",
        LongTimePattern = "HH:mm:ss"
    }
};

CultureInfo.DefaultThreadCurrentCulture = ci;
CultureInfo.DefaultThreadCurrentUICulture = ci;
#endregion

#region Swagger
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api CakeShop", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
#endregion

var app = builder.Build();


#region Migrations Automatic
try
{
    builder.Services.UpdateDatabase(app);
}
catch (Exception ex)
{
    Log.Information($"WebApi - Erro na atualizaçao do banco: {ex.Message}");
}
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
