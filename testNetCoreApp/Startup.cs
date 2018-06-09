using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;



namespace testNetCoreApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc()
                .AddControllersAsServices();
            services.AddApiVersioning( options => {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1,0);
            });            
        }

        public void Configure(IApplicationBuilder app) {
            app.UseMvc();
        }
    }
}