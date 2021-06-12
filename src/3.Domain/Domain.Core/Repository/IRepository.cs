using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Domain.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(string id);
        Task<TEntity> GetByFilter(FilterDefinition<TEntity> filter);
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> Save(TEntity entity);
        Task Update(string id, TEntity entity); 
        Task Delete(string id); 
    }
}
