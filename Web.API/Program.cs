using Application;
using DigitalShop.API.Extensions;
using FluentValidation;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Register Configuration
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

// add layar dependecny 
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApiVersioningExtension();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Database Service
builder.Services.AddDbContext<ApplicationDbContext>(ops => ops.UseNpgsql(configuration.GetConnectionString("ConectaPostgres"),
    b => b.MigrationsAssembly("DigitalShop.API")));
//builder.Services.AddScoped<ITipoService, TipoService>();
//builder.Services.AddScoped<ITipoRepository,TipoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


