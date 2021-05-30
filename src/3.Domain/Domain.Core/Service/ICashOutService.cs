using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Core.Service
{
    public interface ICashOutService : IBaseService<User>
    {
        Task<ICollection<CashOut>> GetAllByUserIdAndMounth(string userId, int month);
        Task<CashOut> Save(string userId, CashOut cashOut);
        Task Update(string userId, CashOut cashOut);
        Task Delete(string userId, string cashOutId);
    }
}
