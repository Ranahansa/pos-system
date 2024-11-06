using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace PosServerApplication.Data.Repositories.Interfaces
{
    public interface IGenericRepository<TDocument>
    {
        Task<IEnumerable<TDocument>> GetAllAsync();
        Task<TDocument> GetByIdAsync(string id);
        Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);
        Task<IEnumerable<TDocument>> FindManyAsync(Expression<Func<TDocument, bool>> filterExpression);
        Task InsertOneAsync(TDocument document);
        Task InsertManyAsync(ICollection<TDocument> documents);
        Task UpdateOneAsync(string id, UpdateDefinition<TDocument> updateDefinition);
        Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);
        Task DeleteByIdAsync(string id);
    }
}