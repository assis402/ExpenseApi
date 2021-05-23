using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Repository;
using Domain.Core.Services;

namespace Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {   
        private readonly IRepository<TEntity> _respository;

        public BaseService(IRepository<TEntity> respository)
        {
            _respository = respository;
        }

        public async Task<TEntity> FindById(string id)
        {
            return await _respository.FindById(id);
        }

        public async Task<ICollection<TEntity>> FindAll()
        {
            return await _respository.FindAll();
        }

        public async Task<TEntity> Save(TEntity entity)
        {
            return await _respository.Save(entity);
        }

        public async Task<TEntity> Update(string id, TEntity entity)
        {
            return await _respository.Update(id, entity);
        }
    }
}
