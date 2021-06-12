using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Repository;
using Domain.Core.Service;
using Domain.Entities;
using System.Linq;
using MongoDB.Driver;

namespace Domain.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IRepository<User> _respository;

        public UserService(IRepository<User> respository) : base(respository)
        {
            _respository = respository;
        }

        public async Task<User> Login(string email, string password)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Where(u => u.Email == email && u.Password == password);
            return await _respository.GetByFilter(filter);
        }
    }
}
