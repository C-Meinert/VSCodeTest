using System;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace testNetCoreApp
{
    /// <summary>
    ///  The hosting class
    /// </summary>
    public class Program
    {
        /// <summary>
        ///  Program Entry Point
        /// </summary>
        public static void Main(string[] args)
        {
            // Setup self host
            Console.WriteLine("Starting Kestrel");
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
