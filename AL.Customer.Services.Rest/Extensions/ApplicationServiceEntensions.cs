using AL.Customer.Data.DbModels;
using AL.Customer.Data.Extension;
using AL.Customer.Domain.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AL.Customer.Services.Rest.Extensions
{
    public static class ApplicationServiceEntensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddDataRepository();
            services.AddServiceRepository();
            services.AddDbContext<FirstMarketContext>(options =>
                        options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;

        }
    }
}
