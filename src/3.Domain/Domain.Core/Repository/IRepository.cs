using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindById(string id);
        Task<ICollection<TEntity>> FindAll();
        Task<TEntity> Save(TEntity entity);
        Task<TEntity> Update(string id, TEntity entity); 
    }
}
