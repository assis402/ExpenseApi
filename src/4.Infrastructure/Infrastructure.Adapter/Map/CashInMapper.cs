using System.Collections.Generic;
using System.Linq;
using Application.DTO;
using Infrastructure.Adapter.Interfaces;
using Domain.Entities;
using MongoDB.Bson;

namespace Infrastructure.Adapter.Map
{
    public class CashInMapper : ICashInMapper
    {
        List<CashInDTO> CashInDTOs = new List<CashInDTO>();

        public CashIn MapperToEntity(CashInDTO cashInDTO)
        {
            if(cashInDTO.Id != null)
            {
                CashIn CashIn = new CashIn
                (
                    cashInDTO.Id,
                    cashInDTO.Description,
                    cashInDTO.Month,
                    cashInDTO.Value,
                    cashInDTO.CreationDate
                );

                return CashIn;
            }
            else 
            {
                CashIn CashIn = new CashIn
                (
                    cashInDTO.Description,
                    cashInDTO.Month,
                    cashInDTO.Value,
                    cashInDTO.CreationDate
                );
                
                return CashIn;
            }
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