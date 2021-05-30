using System.Collections.Generic;
using Application.DTO;
using Domain.Entities;

namespace Infrastructure.Adapter.Interfaces
{
    public interface ICashOutMapper
    {
        CashOut MapperToEntity(CashOutDTO cashOutDTO);
        ICollection<CashOutDTO> MapperListCashOut(ICollection<CashOut> CashOuts);
        CashOutDTO MapperToDTO(CashOut cashOut);
    }
}