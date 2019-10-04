using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
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
        /// Set up services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILoggingService, LoggingService>();
            services.AddControllers();
            // services.AddApiVersioning(o =>
            // {
            //     o.DefaultApiVersion = new ApiVersion(2, 0);
            //     o.AssumeDefaultVersionWhenUnspecified = true;
            // });

            ConfigureSwagger(services);
        }

        /// <summary>
        /// Configure App
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
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