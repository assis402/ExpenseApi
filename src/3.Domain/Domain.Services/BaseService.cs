using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Repository;
using Domain.Core.Service;

namespace Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {   
        private readonly IRepository<TEntity> _respository;

        public BaseService(IRepository<TEntity> respository)
        {
            _respository = respository;
        }

        public async Task<TEntity> GetById(string id)
        {
            return await _respository.GetById(id);
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            return await _respository.GetAll();
        }

        public async Task<TEntity> Save(TEntity entity)
        {
            return await _respository.Save(entity);
        }

        public async Task Update(string id, TEntity entity)
        {
            await _respository.Update(id, entity);
        }
    }
}
