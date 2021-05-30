using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Core.Service
{
    public interface ICashInService : IBaseService<User>
    {
        Task<ICollection<CashIn>> GetAllByUserIdAndMounth(string userId, int month);
        Task<CashIn> Save(string userId, CashIn cashIn);
        Task Update(string userId, CashIn cashIn);
        Task Delete(string userId, string cashInId);
    }
}
