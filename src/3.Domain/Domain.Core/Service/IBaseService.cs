using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Service
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(string id);
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> Save(TEntity entity);
        Task Update(string id, TEntity entity); 
    }
}
