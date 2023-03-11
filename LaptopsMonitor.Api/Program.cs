using LaptopsMonitor.DataClients.Laptops;
using LaptopsMonitor.Entities;
using LaptopsMonitor.Extensions;
using LaptopsMonitor.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddSerializerJsonOptions()
    .AddDataClient<LaptopOptions, LaptopsDataClient, LaptopsParam, Laptop>();

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