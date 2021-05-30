using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICashInApplication
    {
        Task<ICollection<CashInDTO>> GetAllByUserIdAndMounth(string userId, int month);
        Task<CashInDTO> Save(CashInDTO cashInDTO);
        Task Update(CashInDTO cashInDTO);
        Task Delete(CashInDTO cashIn);
    }
}