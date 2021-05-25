using System.Collections.Generic;
using Application.DTO;
using Domain.Entities;

namespace Infrastructure.Adapter.Interfaces
{
    public interface ICashInMapper
    {
        CashIn MapperToEntity(CashInDTO cashInDTO);
        ICollection<CashInDTO> MapperListCashIn(ICollection<CashIn> CashIns);
        CashInDTO MapperToDTO(CashIn cashIn);
    }
}