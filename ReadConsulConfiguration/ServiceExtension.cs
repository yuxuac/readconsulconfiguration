using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ReadConsulConfiguration
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddConsul(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                // Consul address  
                var address = configuration["Consul:Host"];
                consulConfig.Address = new Uri(address);
            }, null, handlerOverride =>
            {
                //disable proxy of httpclienthandler  
                handlerOverride.Proxy = null;
                handlerOverride.UseProxy = false;
            }));
            return services;
        }
    }
}
