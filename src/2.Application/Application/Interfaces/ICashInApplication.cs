using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICashInApplication
    {
        Task<ICollection<CashInDTO>> FindAll();
        Task<CashInDTO> Save(CashInDTO cashInDTO);
    }
}