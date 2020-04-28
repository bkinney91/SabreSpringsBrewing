using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SabreSprings.Brewing.Web.Hubs;
using Newtonsoft.Json;
using SabreSprings.Brewing.Data;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Services;
using SabreSprings.Brewing.Services.Interfaces;
using Serilog;

namespace SabreSprings.Brewing.TapHouse
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
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
                services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:8080");
                });
            });

            // disable automatic model validation
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSignalR();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //Create and register logger
            ILogger logger = new LoggerConfiguration()
                                .WriteTo.Console()
                                .WriteTo.File("Log-.txt", rollingInterval: RollingInterval.Day)
                                .CreateLogger();
            //Register logger
            builder.RegisterInstance(logger);
            //Data Providers
            builder.RegisterType<BatchDataProvider>().As<IBatchDataProvider>();
            builder.RegisterType<BeerDataProvider>().As<IBeerDataProvider>();
            builder.RegisterType<FermentabuoyLogDataProvider>().As<IFermentabuoyLogDataProvider>();
            //Services
            builder.RegisterType<TapService>().As<ITapService>();
            builder.RegisterType<BatchService>().As<IBatchService>();
            builder.RegisterType<FermentabuoyLogService>().As<IFermentabuoyLogService>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors(r => r.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:8080"));
            app.UseRouting();

            app.UseAuthorization();

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
