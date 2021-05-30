using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Repository;
using Domain.Core.Service;
using Domain.Entities;
using System.Linq;

namespace Domain.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IRepository<User> _respository;

        public UserService(IRepository<User> respository) : base(respository)
        {
            _respository = respository;
        }
    }
}
