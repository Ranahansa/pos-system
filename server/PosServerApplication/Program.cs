using Microsoft.Extensions.Options;
using MongoDB.Driver;
using DotNetEnv;
using PosServerApplication.Data.Context;


namespace PosServerApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Load environment variables from .env file
            DotNetEnv.Env.Load();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureServices(builder.Services);

            builder.Services.AddControllers();

            // Configure Swagger/OpenAPI for development
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }

        // Method to configure services for dependency injection
        private static void ConfigureServices(IServiceCollection services)
        {
            // Load MongoDB connection settings from environment variables
            var connectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");
            var databaseName = Environment.GetEnvironmentVariable("MONGODB_DATABASE_NAME");

            // Register MongoDB client as a singleton
            services.AddSingleton<IMongoClient>(sp =>
            {
                if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
                {
                    throw new InvalidOperationException("MongoDB configuration is missing in environment variables.");
                }
                return new MongoClient(connectionString);
            });

            // Register MongoDB context with the injected client and database name
            services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return new ApplicationDbContext(client, databaseName);
            });
        }
    }
}
