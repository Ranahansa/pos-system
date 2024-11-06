using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PosServerApplication.Data.Context;
using PosServerApplication.Repositories.Implementations;
using PosServerApplication.Repositories.Interfaces;

namespace PosServerApplication.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
