using System.Collections.Generic;
using System.Security.Authentication;
using Mmu.Ddws.Common.ApplicationSettings.Models;
using Mmu.Ddws.Common.ApplicationSettings.Services;
using Mmu.Ddws.Domain.Services.Data.Common.MongoDbInitialization;
using MongoDB.Driver;

namespace Mmu.Ddws.Domain.Services.Data.Common.Repositories.Handlers.Implementation
{
    public class MongoClientFactory : IMongoClientFactory
    {
        private readonly MongoDbSettings _mongoDbSettings;

        public MongoClientFactory(IAppSettingsProvider appSettingsProvider, IMongoDbInitializationService mongoDbInitializationService)
        {
            mongoDbInitializationService.AssureEverythingIsInitialized();
            _mongoDbSettings = appSettingsProvider.GetAppSettings().MongoDbSettings;
        }

        public MongoClient Create()
        {
            var clientSettings = new MongoClientSettings
            {
                Server = new MongoServerAddress(_mongoDbSettings.Host, _mongoDbSettings.Port),
                UseSsl = _mongoDbSettings.UseSsl
            };

            if (clientSettings.UseSsl)
            {
                clientSettings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = SslProtocols.Tls12
                };
            }

            var identity = new MongoInternalIdentity(_mongoDbSettings.DatabaseName, _mongoDbSettings.UserName);
            var evidence = new PasswordEvidence(_mongoDbSettings.Password);
            clientSettings.Credentials = new List<MongoCredential>
            {
                new MongoCredential("SCRAM-SHA-1", identity, evidence)
            };

            var mongoClient = new MongoClient(clientSettings);
            return mongoClient;
        }
    }
}