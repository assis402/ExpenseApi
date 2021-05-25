using System.Collections.Generic;
using Application.DTO;
using Infrastructure.Adapter.Interfaces;
using Domain.Entities;

namespace Infrastructure.Adapter.Map
{
    public class CashInMapper : ICashInMapper
    {
        ICollection<CashInDTO> CashInDTOs { get; set; }

        public CashIn MapperToEntity(CashInDTO CashInDTO)
        {
            CashIn CashIn = new CashIn
            (
                CashInDTO.Description,
                CashInDTO.Month,
                CashInDTO.Value
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
                    Value = cashIn.Value
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
                Value = cashIn.Value
            };

            return CashInDTO;
        }
    }
}