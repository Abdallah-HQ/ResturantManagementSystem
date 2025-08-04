using ResturantManagementSystem.Application;
using ResturantManagementSystem.Contract.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDrinkService, DrinkService>();
//builder.Services.AddSingleton<IDrinkService, DrinkService>();
//builder.Services.AddScoped<IDrinkService, DrinkService>();

var app = builder.Build();

app.Environment.IsProduction();

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
