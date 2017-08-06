using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Ddws.Domain.Common.ModelAbstractions;
using Mmu.Ddws.Domain.Services.Common.Repositories;
using Mmu.Ddws.Domain.Services.Infrastructure.Repositories.Handlers;
using MongoDB.Driver;

namespace Mmu.Ddws.Domain.Services.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : AggregateRoot
    {
        private readonly IMongoDbFilterDefinitionFactory<T> _filterFactory;
        private readonly IMongoDbAccess _mongoDbAccess;

        public Repository(IMongoDbAccess mongoDbAccess, IMongoDbFilterDefinitionFactory<T> filterFactory)
        {
            _mongoDbAccess = mongoDbAccess;
            _filterFactory = filterFactory;
        }

        public Task DeleteAsync(string id)
        {
            var collection = _mongoDbAccess.GetDatabaseCollection<T>();
            return collection.DeleteOneAsync(x => x.Id == id);
        }

        public Task<IReadOnlyCollection<T>> LoadAllAsync()
        {
            var result = LoadAsync(x => true);
            return result;
        }

        public async Task<IReadOnlyCollection<T>> LoadAsync(Expression<Func<T, bool>> predicate)
        {
            var collection = _mongoDbAccess.GetDatabaseCollection<T>();
            var filter = _filterFactory.CreateFilterDefinition(predicate);
            var result = await collection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<T> LoadByIdAsync(string id)
        {
            var entries = await LoadAsync(x => x.Id == id);
            var result = entries.SingleOrDefault();
            return result;
        }

        public async Task<T> SaveAsync(T aggregateRoot)
        {
            var collection = _mongoDbAccess.GetDatabaseCollection<T>();
            if (string.IsNullOrWhiteSpace(aggregateRoot.Id))
            {
                await collection.InsertOneAsync(aggregateRoot);
                return aggregateRoot;
            }

            var filter = _filterFactory.CreateFilterDefinition(x => x.Id == aggregateRoot.Id);
            var updateOptions = new FindOneAndReplaceOptions<T> { IsUpsert = false, ReturnDocument = ReturnDocument.After };
            var result = await collection.FindOneAndReplaceAsync(filter, aggregateRoot, updateOptions);
            return result;
        }
    }
}