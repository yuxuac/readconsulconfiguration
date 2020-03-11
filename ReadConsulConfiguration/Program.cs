using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Winton.Extensions.Configuration.Consul;

namespace ReadConsulConfiguration
{
    public class Program
    {
        public static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            cancellationTokenSource.Cancel();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          //.ConfigureAppConfiguration((hostingContext, builder) => 
                          //{
                          //    builder.AddConsul(
                          //        "App1/appsettings.json", // Cousul key/value path to load the key
                          //        cancellationTokenSource.Token, 
                          //        options =>
                          //        {
                          //            options.ConsulConfigurationOptions = cco => { cco.Address = new Uri("http://127.0.0.1:8500"); };
                          //            options.Optional = true;
                          //            options.ReloadOnChange = true;
                          //            options.OnLoadException = exceptionContext => { exceptionContext.Ignore = true; };
                          //        }).AddEnvironmentVariables();
                          //})
                          .UseStartup<Startup>();
        }
            
    }
}
