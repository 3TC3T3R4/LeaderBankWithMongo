using AutoMapper.Data;
using LeaderBank.Mongo.API.AutoMapper;
using LeaderBank.Mongo.Domain.UseCases.Gateway;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Domain.UseCases.UseCases;
using LeaderBank.Mongo.Domain.UseCases;
using LeaderBank.Mongo.Domain.UseCases.Gateway.Repositories;
using LeaderBank.Mongo.Domain.UseCases.UseCases;
using LeaderBank.Mongo.Domain.UseCases.Gateway;
using LeaderBank.Mongo.Infrastructure;
using LeaderBank.Mongo.Infrastructure.Interfaces;
using LeaderBank.Mongo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));

builder.Services.AddScoped<IAdvisorUseCase, AdvisorUseCase>();
builder.Services.AddScoped<IAdvisorRepository, AdvisorRepository>();
builder.Services.AddScoped<ICustomerUseCase, CustomerUseCase>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<ICardUseCase, CardUseCase>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ITransactionUseCase, TransactionUseCase>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddSingleton<IContext>(provider => new Context(builder.Configuration.GetConnectionString("urlConnection"), "LeaderBank"));

var app = builder.Build();

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
