using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using testNetCoreApp.Utilities.Logging;
using testNetCoreApp.Utilities.Swagger;

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
        public IConfiguration Configuration { get; }

        private readonly bool _isDevelopment;

        /// <summary>
        /// Constructor mostly used to perform some "pre-startup" tasks
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostEnvironment env)
        {
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
            // Add API controllers as services
            services.AddControllers();
            ConfigureApiVersioning(services);
            // Add and configure Serilog
            SeriLogConfig.AddSerilogServices(services, Configuration);
            // Configure seagger settings
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();  
            ConfigureSwagger(services);
        }

        /// <summary>
        /// Configure App
        /// </summary>
        /// <param name="app"></param>
        /// <param name="provider"></param>
        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            if (_isDevelopment)
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // build a swagger endpoint for each discovered API version
                foreach(var description in provider.ApiVersionDescriptions) {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
        }

        /// <summary>
        /// Configure API versioning
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureApiVersioning(IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddVersionedApiExplorer(o =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                o.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                o.SubstituteApiVersionInUrl = true;
                o.SubstitutionFormat = "VVV";
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
                c.OperationFilter<SwaggerDefaultValues>();
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