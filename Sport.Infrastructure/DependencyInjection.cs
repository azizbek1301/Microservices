using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sport.DataApplication.Abstraction;
using Sport.Infrastructure.Peristance;

namespace Sport.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            return services;
        }
    }
}
