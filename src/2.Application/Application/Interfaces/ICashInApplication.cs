using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICashInApplication
    {
        Task<ICollection<CashIn>> FindAll();
        Task<CashIn> Save(CashIn cashIn);
    }
}