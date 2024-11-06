using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PosServerApplication.Data.Context;
using PosServerApplication.Models.Configurations;
using PosServerApplication.Settings;

namespace PosServerApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureServices(builder.Services, builder.Configuration);

            builder.Services.AddControllers();
            // Configure Swagger/OpenAPI
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
        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Configure MongoDB settings from app configuration
            services.Configure<MongoDbSettings>(
                configuration.GetSection("MongoDB"));

            // Register MongoDB client
            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return new MongoClient(settings.ConnectionString);
            });

            // Register MongoDB context
            services.AddScoped<IApplicationDbContext>(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return new ApplicationDbContext(client, settings.DatabaseName);
            });
        }
    }
}
