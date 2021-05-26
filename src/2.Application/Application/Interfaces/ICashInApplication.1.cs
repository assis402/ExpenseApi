using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICashInApplication
    {
        Task<ICollection<CashInDTO>> GetAll();
        Task<CashInDTO> Save(CashInDTO cashInDTO);
    }
}