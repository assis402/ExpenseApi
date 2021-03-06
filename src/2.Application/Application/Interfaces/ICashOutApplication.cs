using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICashOutApplication
    {
        Task<ICollection<CashOutDTO>> GetAllByUserIdAndMounth(GetCashOutDTO getCashOutDTO);
        Task<CashOutDTO> Save(CashOutDTO cashOutDTO);
        Task Update(CashOutDTO cashOutDTO);
        Task Delete(DeleteCashOutDTO deleteCashOutDTO);
    }
}