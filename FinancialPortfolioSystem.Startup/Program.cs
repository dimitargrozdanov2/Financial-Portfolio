using FinancialPortfolioSystem.Application;
using FinancialPortfolioSystem.Infrastructure;
using FinancialPortfolioSystem.Startup;
using FinancialPortfolioSystem.Web;
using FinancialPortfolioSystem.Web.Extensions;
using FinancialPortfolioSystem.Web.Façade;

var builder = WebApplication.CreateBuilder(args);
var builderConfiguration = builder.Configuration;


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.RegisterFactories();
builder.Services.RegisterTransientInterfaces();
builder.Services.AddApplication(builderConfiguration);
builder.Services.AddInfrastructure(builderConfiguration);
builder.Services.AddWebComponents();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Initialize();
app.Run();
