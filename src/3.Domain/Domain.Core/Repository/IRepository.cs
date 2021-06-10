using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(string id);
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> Save(TEntity entity);
        Task Update(string id, TEntity entity); 
        Task Delete(string id); 
    }
}
