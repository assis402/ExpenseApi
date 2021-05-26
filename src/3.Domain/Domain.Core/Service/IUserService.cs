using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Core.Service
{
    public interface IUserService : IBaseService<User>
    {
        Task<ICollection<CashIn>> GetAllCashInByUserIdAndMounth(string userId, int month);
        Task<ICollection<CashOut>> GetAllCashOutByUserIdAndMounth(string userId, int month);
    }
}
