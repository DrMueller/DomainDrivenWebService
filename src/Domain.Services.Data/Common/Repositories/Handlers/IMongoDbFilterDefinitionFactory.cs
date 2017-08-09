using System;
using System.Linq.Expressions;
using Mmu.Ddws.Domain.Infrastructure.ModelAbstractions;
using MongoDB.Driver;

namespace Mmu.Ddws.Domain.Services.Data.Common.Repositories.Handlers
{
    public interface IMongoDbFilterDefinitionFactory<T>
        where T : AggregateRoot
    {
        FilterDefinition<T> CreateFilterDefinition(Expression<Func<T, bool>> predicate);
    }
}