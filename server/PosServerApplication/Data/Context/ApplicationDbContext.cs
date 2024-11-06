using MongoDB.Driver;
using PosServerApplication.Models.Attributes;
using System;

namespace PosServerApplication.Data.Context
{
    public class ApplicationDbContext
    {
        private readonly IMongoDatabase _database;
        private IMongoClient client;
        private string? databaseName;

        public ApplicationDbContext()
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");
            var databaseName = Environment.GetEnvironmentVariable("MONGODB_DATABASE_NAME");

            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
            {
                throw new InvalidOperationException("MongoDB connection string or database name is missing.");
            }

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public ApplicationDbContext(IMongoClient client, string? databaseName)
        {
            this.client = client;
            this.databaseName = databaseName;
        }

        public IMongoCollection<T> GetCollection<T>() where T : class
        {
            // Assuming your BsonCollection attribute is still used
            var attribute = (BsonCollectionAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(BsonCollectionAttribute));
            if (attribute == null)
                throw new ArgumentException($"Collection attribute is missing for {typeof(T).Name}");

            return _database.GetCollection<T>(attribute.CollectionName);
        }
    }
}
