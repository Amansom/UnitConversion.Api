using UnitConversion.Api.Interfaces;
using UnitConversion.Api.Middleware;
using UnitConversion.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IConversionService, ConversionService>();

var app = builder.Build();

// Configure middleware
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();