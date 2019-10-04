using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using testNetCoreApp.Utilities.Logging;

namespace testNetCoreApp
{
    /// <summary>
    ///  This class is used to configure all the runtime hosting settings
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Application Settings
        /// </summary>
        /// <value></value>
        public IConfiguration Configuration {get;}
        
        private readonly bool _isDevelopment;
    
        /// <summary>
        /// Constructor mostly used to perform some "pre-startup" tasks
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostEnvironment env) {
            _isDevelopment = env.IsDevelopment();
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
        }

        /// <summary>
        /// Set up services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // services.AddApiVersioning(o =>
            // {
            //     o.DefaultApiVersion = new ApiVersion(2, 0);
            //     o.AssumeDefaultVersionWhenUnspecified = true;
            // });

            SeriLogConfig.AddSerilogServices(services, Configuration);
            ConfigureSwagger(services);
        }

        /// <summary>
        /// Configure App
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app)
        {
            if(_isDevelopment)
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }

        /// <summary>
        /// configure swagger gen
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test Api", Version = "v1" });
                c.IncludeXmlComments(xmlDoc);
            });
        }

        /// <summary>
        /// Gets the full path to the generate XML doc
        /// </summary>
        /// <returns></returns>
        private static string xmlDoc =>
            Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");            
    }
}