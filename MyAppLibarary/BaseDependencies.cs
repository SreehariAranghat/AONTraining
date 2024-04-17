using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MyAppLibarary
{
    public static class BaseDependencies
    {
        public static IServiceCollection RegisterPlatform(this IServiceCollection services)
        {
            //services.AddMvc();

            return services;
        }
    }
}
