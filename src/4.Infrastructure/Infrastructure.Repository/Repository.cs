using System.Threading.Tasks;
using System.Collections.Generic;
using Infrastructure.Data;
using MongoDB.Driver;
using Domain.Core.Repository;
using MongoDB.Bson;

namespace Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ExpenseDB _expenseDB;
        private IMongoCollection<TEntity> _entityCollection;

        public Repository(ExpenseDB expenseDB)
        {
            _expenseDB = expenseDB;
            _entityCollection = _expenseDB.DB.GetCollection<TEntity>(typeof(TEntity).Name.ToLower());
        }

        public async Task<TEntity> Save(TEntity entity)
        {
            await _entityCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<TEntity> GetById(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id));
            var entity = await _entityCollection.Find(filter).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            var entities = await _entityCollection.Find(Builders<TEntity>.Filter.Empty).ToListAsync();

            return entities;
        }

        public async Task Update(string id, TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id));
            await _entityCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id));
            await _entityCollection.DeleteOneAsync(filter);
        }
    }
}
