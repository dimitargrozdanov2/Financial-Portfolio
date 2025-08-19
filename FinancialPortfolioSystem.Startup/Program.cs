using FinancialPortfolioSystem.Application;
using FinancialPortfolioSystem.Domain.Factories.Assets;
using FinancialPortfolioSystem.Infrastructure;
using FinancialPortfolioSystem.Web.Extensions;
using FinancialPortfolioSystem.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using NSwag.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var builderConfiguration = builder.Configuration;


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.RegisterFactories();
builder.Services.RegisterTransientInterfaces();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builderConfiguration);
builder.Services.RegisterMappings();
builder.Services.AddScoped<IAppMediator, AppMediator>();
builder.Services.AddOpenApiDocument();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseValidationExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
