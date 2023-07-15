using System.Text.Json.Serialization;
using Newme.Payment.API.Configurations;
using Newme.Payment.Application;
using Newme.Payment.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => 
        options.JsonSerializerOptions.Converters
            .Add(new JsonStringEnumConverter()));

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerConfiguration();

builder.Services
    .AddApplicationModule()
    .AddInfrastructureModule();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

