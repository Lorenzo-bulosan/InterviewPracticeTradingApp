using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TradingApp.Data;
using TradingApp.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TradingDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("TradingDatabase")));

builder.Services.AddScoped<TradingService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

try
{
    app.MapControllers();

    app.Run();
}
catch (ReflectionTypeLoadException ex)
{
    Console.WriteLine("========== REAL LOADER ERRORS ==========");

    foreach (var error in ex.LoaderExceptions)
    {
        Console.WriteLine(error);
    }

    Console.WriteLine("========================================");

    throw;
}