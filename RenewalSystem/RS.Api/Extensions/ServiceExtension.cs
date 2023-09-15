using Elsa;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.SqlServer;
namespace RS.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureElsaServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElsa(option => option.UseEntityFrameworkPersistence(config => config.UseSqlServer(configuration.GetConnectionString("MigrationDb")))
                                             .AddQuartzTemporalActivities()
                                             .AddEmailActivities(email =>
                                             {
                                                 email.Host = configuration["Elsa:Smtp:Host"];
                                                 email.Port = int.Parse(configuration["Elsa:Smtp:Port"]!);
                                                 email.DefaultSender = configuration["Elsa:Smtp:Username"];
                                                 email.UserName = configuration["Elsa:Smtp:Username"];
                                                 email.Password = configuration["Elsa:Smtp:Password"];
                                                 email.RequireCredentials = true;
                                             })
                                             .AddActivitiesFrom(typeof(Program).Assembly)
                                             .AddWorkflowsFrom(typeof(Program).Assembly));
        }
    }
}
