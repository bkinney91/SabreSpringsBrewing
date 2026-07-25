using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;
using SabreSprings.Brewing.BrewController.Api.Hubs;
using SabreSprings.Brewing.BrewController.HostedServices;
using SabreSprings.Brewing.BrewController.Services;
using SabreSprings.Brewing.BrewController.Services.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls(builder.Environment.IsDevelopment()
    ? "http://localhost:8090"
    : "http://*:8080");
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>((_, container) =>
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("Log-.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    container.RegisterType<KettleService>().As<IKettleService>().SingleInstance();
    container.RegisterType<MashService>().As<IMashService>().SingleInstance();
    container.RegisterType<PumpService>().As<IPumpService>().SingleInstance();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("BrewControllerClient", policy =>
    {
        policy.WithOrigins("http://localhost:8080", "http://10.0.0.2", "http://10.0.0.2:8000", "http://10.0.0.5", "http://10.0.0.5:8000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddHostedService<KettleHostedService>();
builder.Services.AddHostedService<MashHostedService>();
builder.Services.AddHostedService<PumpHostedService>();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SabreSprings.Brewing.BrewController.Api",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SabreSprings.Brewing.BrewController.Api v1"));
}

app.UseCors("BrewControllerClient");
app.MapControllers();
app.MapHub<KettleHub>("/kettleHub");
app.MapHub<MashHub>("/mashHub");
app.MapHub<PumpHub>("/pumpHub");

app.Run();
