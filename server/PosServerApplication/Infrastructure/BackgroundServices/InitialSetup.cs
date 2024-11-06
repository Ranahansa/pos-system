using MongoDB.Driver;
using PosServerApplication.Data.Context;
using PosServerApplication.Models.Entities;

namespace PosServerApplication.Infrastructure.BackgroundServices
{
    public class InitialSetup
    {
        private readonly ApplicationDbContext _context;

        public InitialSetup(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateIndexesAsync()
        {
            var userCollection = _context.GetCollection<User>();

            var emailIndex = Builders<User>.IndexKeys.Ascending(x => x.Email);
            await userCollection.Indexes.CreateOneAsync(new CreateIndexModel<User>(emailIndex, new CreateIndexOptions { Unique = true }));

            var usernameIndex = Builders<User>.IndexKeys.Ascending(x => x.Username);
            await userCollection.Indexes.CreateOneAsync(new CreateIndexModel<User>(usernameIndex, new CreateIndexOptions { Unique = true }));
        }
    }
}
