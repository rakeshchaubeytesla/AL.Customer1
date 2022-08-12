using AL.Customer.Data.Interface;
using AL.Customer.Data.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Data.Extension
{
    public static class RepositoryModuleExtenstion
    {
        public static void AddDataRepository(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
