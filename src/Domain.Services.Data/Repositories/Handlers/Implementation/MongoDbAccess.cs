using Mmu.Ddws.Common.ApplicationSettings.Models;
using Mmu.Ddws.Common.ApplicationSettings.Services;
using Mmu.Ddws.Domain.Common.ModelAbstractions;
using MongoDB.Driver;

namespace Mmu.Ddws.Domain.Services.Infrastructure.Repositories.Handlers.Implementation
{
    public class MongoDbAccess : IMongoDbAccess
    {
        private readonly IMongoClientFactory _mongoClientFactory;
        private readonly MongoDbSettings _mongoDbSettings;

        public MongoDbAccess(IMongoClientFactory mongoClientFactory, IAppSettingsProvider appSettingsProvider)
        {
            _mongoClientFactory = mongoClientFactory;
            _mongoDbSettings = appSettingsProvider.GetAppSettings().MongoDbSettings;
        }

        public IMongoCollection<T> GetDatabaseCollection<T>()
            where T : AggregateRoot
        {
            var collectionName = typeof(T).Name;
            var db = GetDatabase();
            var result = db.GetCollection<T>(collectionName);

            return result;
        }

        private IMongoDatabase GetDatabase()
        {
            var mongoClient = _mongoClientFactory.Create();
            var database = mongoClient.GetDatabase(_mongoDbSettings.DatabaseName);
            return database;
        }
    }
}