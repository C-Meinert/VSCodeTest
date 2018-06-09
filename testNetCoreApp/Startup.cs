using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.HttpSys;
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
        }

        public void Configure(IApplicationBuilder app) {
            app.UseMvc();
        }
    }
}