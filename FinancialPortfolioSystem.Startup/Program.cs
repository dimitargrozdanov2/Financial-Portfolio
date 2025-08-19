using FinancialPortfolioSystem.Application;
using FinancialPortfolioSystem.Infrastructure;
using FinancialPortfolioSystem.Web.Extensions;
using FinancialPortfolioSystem.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);
var builderConfiguration = builder.Configuration;


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builderConfiguration);
builder.Services.RegisterMappings();
builder.Services.AddScoped<IAppMediator, AppMediator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseValidationExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
