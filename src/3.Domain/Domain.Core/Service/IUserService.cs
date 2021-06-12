using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Core.Service
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> Login(string email, string password);
    }
}
