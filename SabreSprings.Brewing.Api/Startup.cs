using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SabreSprings.Brewing.Api.Hubs;
using Newtonsoft.Json;
using SabreSprings.Brewing.Data;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Services;
using SabreSprings.Brewing.Services.Interfaces;
using Serilog;
using Autofac;

namespace SabreSprings.Brewing.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(option => option.EnableEndpointRouting = false)
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            //    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:8080", "http://10.0.0.2", "http://10.0.0.2:8000");
                });
            });

            // disable automatic model validation
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddControllers();
            services.AddSignalR();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //Create and register logger
            Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console()
                                .WriteTo.File("Logs/ApiLog-.txt", rollingInterval: RollingInterval.Day)
                                .CreateLogger();
            Log.Information("Logger succesfully created");
            //Data Providers
            builder.RegisterType<BatchDataProvider>().As<IBatchDataProvider>();
            builder.RegisterType<BeerDataProvider>().As<IBeerDataProvider>();
            builder.RegisterType<FermentabuoyLogDataProvider>().As<IFermentabuoyLogDataProvider>();
            builder.RegisterType<FermentabuoyDataProvider>().As<IFermentabuoyDataProvider>();
            builder.RegisterType<FermentabuoyAssignmentDataProvider>().As<IFermentabuoyAssignmentDataProvider>();
            builder.RegisterType<FermentationTankDataProvider>().As<IFermentationTankDataProvider>();

            //Services
            builder.RegisterType<TapService>().As<ITapService>();
            builder.RegisterType<BatchService>().As<IBatchService>();
            builder.RegisterType<BeerService>().As<IBeerService>();
            builder.RegisterType<FermentabuoyLogService>().As<IFermentabuoyLogService>();
            builder.RegisterType<FermentabuoyService>().As<IFermentabuoyService>();
            builder.RegisterType<FermentabuoyAssignmentService>().As<IFermentabouyAssignmentService>();
            builder.RegisterType<FermentationTankService>().As<IFermentationTankService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors(r => r.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:8080", "http://10.0.0.2", "http://10.0.0.2:8000"));
            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<TapHub>("/tapHub");
            });


        }
    }
}
