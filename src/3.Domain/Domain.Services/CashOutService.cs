using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Repository;
using Domain.Core.Service;
using Domain.Entities;
using System.Linq;

namespace Domain.Services
{
    public class CashOutService : BaseService<User>, ICashOutService
    {
        private readonly IRepository<User> _respository;

        public CashOutService(IRepository<User> respository) : base(respository)
        {
            _respository = respository;
        }

        public async Task<ICollection<CashOut>> GetAllByUserIdAndMounth(string userId, int month)
        {
            User user = await _respository.GetById(userId);
            return user.CashOuts.Where(cashOut => cashOut.Month == month).OrderBy(cashOut => cashOut.Id).ToList();
        }

        public async Task<CashOut> Save(string userId, CashOut cashOut)
        {
            User user = await _respository.GetById(userId);
            user.CashOuts.Add(cashOut);
            await _respository.Update(user.Id.ToString(), user);
            return cashOut;
        }

        public async Task Update(string userId, CashOut cashOut)
        {
            User user = await _respository.GetById(userId);
            user.CashOuts.Where(c => c.Id == cashOut.Id).Select(c => { c.Value = cashOut.Value; return c; }).ToList();
            await _respository.Update(user.Id.ToString(), user);
        }

        public async Task Delete(string userId, string cashOutId)
        {
            User user = await _respository.GetById(userId);
            user.CashOuts.Remove(user.CashOuts.Single(x => x.Id.ToString() == cashOutId));
            await _respository.Update(user.Id.ToString(), user);
        }
    }
}
