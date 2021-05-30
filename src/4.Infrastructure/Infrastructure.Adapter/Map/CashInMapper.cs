using System.Collections.Generic;
using Application.DTO;
using Infrastructure.Adapter.Interfaces;
using Domain.Entities;

namespace Infrastructure.Adapter.Map
{
    public class CashInMapper : ICashInMapper
    {
        List<CashInDTO> CashInDTOs = new List<CashInDTO>();

        public CashIn MapperToEntity(CashInDTO cashInDTO)
        {
            CashIn CashIn = new CashIn
            (
                cashInDTO.Description,
                cashInDTO.Month,
                cashInDTO.Value
            );

            return CashIn;
        }

        public ICollection<CashInDTO> MapperListCashIn(ICollection<CashIn> cashIns)
        {
            foreach (var cashIn in cashIns)
            {
                CashInDTO CashInDTO = new CashInDTO
                {
                    Id = cashIn.Id.ToString(),
                    Description = cashIn.Description,
                    Month = cashIn.Month,
                    Value = cashIn.Value,
                    CreationDate = cashIn.CreationDate
                };

                CashInDTOs.Add(CashInDTO);
            }

            return CashInDTOs;
        }

        public CashInDTO MapperToDTO(CashIn cashIn)
        {
            CashInDTO CashInDTO = new CashInDTO
            {
                Id = cashIn.Id.ToString(),
                Description = cashIn.Description,
                Month = cashIn.Month,
                Value = cashIn.Value,
                CreationDate = cashIn.CreationDate
            };

            return CashInDTO;
        }
    }
}