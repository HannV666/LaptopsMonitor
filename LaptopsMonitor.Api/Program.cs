using LaptopsMonitor.Api.Extensions;
using LaptopsMonitor.Infrastructure.DependencyInjection;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMongoClient(settings =>
{
    var host = builder.Configuration["MongoAddress:Host"];
    var port = builder.Configuration.GetSection("MongoAddress:Port").Get<int>();

    settings.Server = new MongoServerAddress(host, port);
});

builder.Services
    .AddSerializerJsonOptions()
    .AddLaptopsDataClient()
    .AddLaptopRepository()
    .AddMonitoringService();

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