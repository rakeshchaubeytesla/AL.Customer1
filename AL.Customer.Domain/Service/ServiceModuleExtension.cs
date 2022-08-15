using AL.Customer.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Domain.Service
{
    public static class ServiceModuleExtension
    {
        public static void AddServiceRepository(this IServiceCollection services )
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
