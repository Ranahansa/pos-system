using MongoDB.Driver;
using PosServerApplication.Data.Context;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMongoClient>(sp =>
            new MongoClient(configuration.GetConnectionString("MongoDB")));

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}