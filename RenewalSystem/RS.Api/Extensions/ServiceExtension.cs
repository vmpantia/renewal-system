using Microsoft.EntityFrameworkCore;
using RS.BAL.Helpers;
using RS.BAL.Services;
using RS.DAL.Contractors;
using RS.DAL.DataAccess;
using RS.DAL.Repositories;

namespace RS.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RSDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("MigrationDb")));
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CustomerService>();
            services.AddScoped<ProductService>();
            services.AddScoped<SubscriptionService>();
        }
    }
}
