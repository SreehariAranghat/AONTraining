using Microsoft.Extensions.DependencyInjection;
using MyAppLibarary.ForgotPassword;
using MyAppLibarary.SMS;
using MyDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyAppLibarary
{
    public static class AppDependencies
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<ISmsService, AirtelSmsService>();
            services.AddScoped<IPasswordService, PasswordService>();

            services.AddScoped<IDataRepository, SqlDataRepository>();

            return services;
        }
    }
}
