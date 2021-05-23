using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity> FindById(string id);
        Task<ICollection<TEntity>> FindAll();
        Task<TEntity> Save(TEntity entity);
        Task<TEntity> Update(string id, TEntity entity); 
    }
}
