using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Domain.Core.Service;
using Domain.Entities;
using Infrastructure.Adapter.Interfaces;

namespace Application.Services
{
    public class CashOutApplication : ICashOutApplication
    {
        private readonly ICashOutService _service;
        private readonly ICashOutMapper _mapper;

        public CashOutApplication(ICashOutService service, ICashOutMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ICollection<CashOutDTO>> GetAllByUserIdAndMounth(GetCashOutDTO getCashOutDTO)
        {
            var cashOuts = await _service.GetAllByUserIdAndMounth(getCashOutDTO.UserId, getCashOutDTO.Month);
            return _mapper.MapperListCashOut(cashOuts);
        }

        public async Task<CashOutDTO> Save(CashOutDTO cashOutDTO)
        {   
            CashOut cashOut = _mapper.MapperToEntity(cashOutDTO);
            cashOut = await _service.Save(cashOutDTO.UserId, cashOut);
            return _mapper.MapperToDTO(cashOut);
        }

        public async Task Update(CashOutDTO cashOutDTO)
        {   
            CashOut cashOut = _mapper.MapperToEntity(cashOutDTO);
            await _service.Update(cashOutDTO.UserId, cashOut);
        }

        public async Task Delete(DeleteCashOutDTO deleteCashOut)
        {   
            await _service.Delete(deleteCashOut.UserId, deleteCashOut.CashOutId);
        }
    }
}
