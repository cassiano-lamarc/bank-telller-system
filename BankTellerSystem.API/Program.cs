using BankTellerSystem.API.Configurations;
using BankTellerSystem.Application.Accounts.Commands.CreateAccount;
using BankTellerSystem.Application.Configurations;
using BankTellerSystem.InfraData.Configurations;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddContextConfigurations();
builder.Services.AddRepositoriesConfigurations();
builder.Services.AddMediatRAppServices();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAccountCommand>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Bank Teller API", Version = "v1" });
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
