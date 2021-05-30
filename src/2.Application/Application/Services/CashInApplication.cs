using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Domain.Core.Service;
using Domain.Entities;
using Infrastructure.Adapter.Interfaces;

namespace Application.Services
{
    public class CashInApplication : ICashInApplication
    {
        private readonly ICashInService _service;
        private readonly ICashInMapper _mapper;

        public CashInApplication(ICashInService service, ICashInMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ICollection<CashInDTO>> GetAllByUserIdAndMounth(string userId, int month)
        {
            var cashIns = await _service.GetAllByUserIdAndMounth(userId, month);
            return _mapper.MapperListCashIn(cashIns);
        }

        public async Task<CashInDTO> Save(CashInDTO cashInDTO)
        {   
            cashInDTO.CreationDate = DateTime.UtcNow.AddHours(-3);
            CashIn cashIn = _mapper.MapperToEntity(cashInDTO);
            cashIn = await _service.Save(cashInDTO.UserId, cashIn);
            return _mapper.MapperToDTO(cashIn);
        }

        public async Task Update(CashInDTO cashInDTO)
        {   
            CashIn cashIn = _mapper.MapperToEntity(cashInDTO);
            await _service.Update(cashInDTO.UserId, cashIn);
        }

        public async Task Delete(string userId, string cashInId)
        {   
            await _service.Delete(userId, cashInId);
        }
    }
}
