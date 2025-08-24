using FinancialPortfolioSystem.Application;
using FinancialPortfolioSystem.Infrastructure;
using FinancialPortfolioSystem.Infrastructure.Identity;
using FinancialPortfolioSystem.Startup;
using FinancialPortfolioSystem.Web;
using FinancialPortfolioSystem.Web.Extensions;
using FinancialPortfolioSystem.Web.Façade;
using Microsoft.AspNetCore.Identity;
using NSwag;
using NSwag.Generation.Processors.Security;

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
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddOpenApiDocument(doc =>
{
    doc.AddSecurity("bearer", new NSwag.OpenApiSecurityScheme
    {
        Type = OpenApiSecuritySchemeType.ApiKey,
        Name = "Authorization",
        In = OpenApiSecurityApiKeyLocation.Header,
        Description = "Bearer token authorization header",
    });

    doc.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("bearer"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowUI", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // your FE URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
  
var app = builder.Build();
app.UseCors("AllowUI");
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
await app.SeedAdminAsync();
app.Run();

