using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SabreSprings.Brewing.BrewController.HostedServices;
using SabreSprings.Brewing.BrewController.Services;
using SabreSprings.Brewing.BrewController.Services.Interfaces;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.BrewController.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:8080", "http://10.0.0.2", "http://10.0.0.2:8000");
                });
            });
            services.AddControllers();
            services.AddSignalR();
            services.AddHostedService<KettleHostedService>();
            services.AddHostedService<MashHostedService>();
            services.AddHostedService<PumpHostedService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SabreSprings.Brewing.BrewController.Api", Version = "v1" });
            });
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            //Create and register logger
            Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console()
                                .WriteTo.File("Logs/BrewController-.log", rollingInterval: RollingInterval.Day)
                                .CreateLogger();

            builder.RegisterType<KettleService>().As<IKettleService>(); 
            builder.RegisterType<MashService>().As<IMashService>();     
            builder.RegisterType<PumpService>().As<IPumpService>().SingleInstance();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SabreSprings.Brewing.BrewController.Api v1"));
            }

            app.UseRouting();
            app.UseCors(r => r.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:8080", "http://10.0.0.5", "http://10.0.0.5:8000"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<Hubs.KettleHub>("/kettleHub");
                endpoints.MapHub<Hubs.MashHub>("/mashHub");
                endpoints.MapHub<Hubs.PumpHub>("/pumpHub");
            });
        }
    }
}
