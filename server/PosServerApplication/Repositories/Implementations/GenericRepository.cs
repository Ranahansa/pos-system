﻿using MongoDB.Driver;
using PosServerApplication.Data.Context;
using PosServerApplication.Repositories.Interfaces;
using System.Linq.Expressions;

namespace PosServerApplication.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public GenericRepository(ApplicationDbContext context)
        {
            _collection = context.GetCollection<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<T> GetByIdAsync(string id) =>
            await _collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filterExpression) =>
            await _collection.Find(filterExpression).ToListAsync();

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression) =>
            await _collection.Find(filterExpression).FirstOrDefaultAsync();

        public async Task CreateAsync(T entity) =>
            await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, T entity) =>
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> filterExpression) =>
            await _collection.Find(filterExpression).AnyAsync();
    }
}
