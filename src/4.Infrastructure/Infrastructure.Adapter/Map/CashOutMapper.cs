using System.Collections.Generic;
using Application.DTO;
using Infrastructure.Adapter.Interfaces;
using Domain.Entities;

namespace Infrastructure.Adapter.Map
{
    public class CashOutMapper : ICashOutMapper
    {
        List<CashOutDTO> CashOutDTOs = new List<CashOutDTO>();

        public CashOut MapperToEntity(CashOutDTO cashOutDTO)
        {
            CashOut CashOut = new CashOut
            (
                cashOutDTO.Description,
                cashOutDTO.Month,
                cashOutDTO.Value
            );

            return CashOut;
        }

        public ICollection<CashOutDTO> MapperListCashOut(ICollection<CashOut> cashOuts)
        {
            foreach (var cashOut in cashOuts)
            {
                CashOutDTO CashOutDTO = new CashOutDTO
                {
                    Id = cashOut.Id.ToString(),
                    Description = cashOut.Description,
                    Month = cashOut.Month,
                    Value = cashOut.Value
                };

                CashOutDTOs.Add(CashOutDTO);
            }

            return CashOutDTOs;
        }

        public CashOutDTO MapperToDTO(CashOut cashOut)
        {
            CashOutDTO CashOutDTO = new CashOutDTO
            {
                Id = cashOut.Id.ToString(),
                Description = cashOut.Description,
                Month = cashOut.Month,
                Value = cashOut.Value
            };

            return CashOutDTO;
        }
    }
}