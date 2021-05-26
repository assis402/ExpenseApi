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

        public async Task<ICollection<CashIn>> GetAllCashInByUserIdAndMounth(string userId, int month)
        {
            User user = await _respository.GetById(userId);
            return user.CashIns.Where(cashIn => cashIn.Month == month).ToList();
        }

        public async Task<ICollection<CashOut>> GetAllCashOutByUserIdAndMounth(string userId, int month)
        {
            User user = await _respository.GetById(userId);
            return user.CashOuts.Where(cashOut => cashOut.Month == month).ToList();
        }
    }
}
