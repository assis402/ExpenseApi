using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Repository;
using Domain.Core.Service;
using Domain.Entities;
using System.Linq;

namespace Domain.Services
{
    public class CashInService : BaseService<User>, ICashInService
    {
        private readonly IRepository<User> _respository;

        public CashInService(IRepository<User> respository) : base(respository)
        {
            _respository = respository;
        }

        public async Task<ICollection<CashIn>> GetAllByUserIdAndMounth(string userId, int month)
        {
            User user = await _respository.GetById(userId);
            return user.CashIns.Where(cashIn => cashIn.Month == month).OrderBy(cashIn => cashIn.CreationDate).ToList();
        }

        public async Task<CashIn> Save(string userId, CashIn cashIn)
        {
            User user = await _respository.GetById(userId);
            cashIn.SetId();
            user.CashIns.Add(cashIn);
            await _respository.Update(user.Id.ToString(), user);
            return cashIn;
        }

        public async Task Update(string userId, CashIn cashIn)
        {
            User user = await _respository.GetById(userId);
            user.CashIns.Where(c => c.Id == cashIn.Id).Select(c => { c.Update(cashIn); return c; }).ToList();
            await _respository.Update(user.Id.ToString(), user);
        }

        public async Task Delete(string userId, string cashInId)
        {
            User user = await _respository.GetById(userId);
            user.CashIns.Remove(user.CashIns.Single(x => x.Id.ToString() == cashInId));
            await _respository.Update(user.Id.ToString(), user);
        }
    }
}
