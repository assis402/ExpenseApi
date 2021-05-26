using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Domain.Core.Services;
using Domain.Entities;
using Infrastructure.Adapter.Interfaces;

namespace Application.Services
{
    public class CashInApplication : ICashInApplication
    {
        private readonly IBaseService<User> _service;
        private readonly ICashInMapper _mapper;

        public CashInApplication(IBaseService<User> service, ICashInMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ICollection<CashInDTO>> GetAll(string userId)
        {
            var cashIns = await _service.GetAll();
            return _mapper.MapperListCashIn(cashIns);
        }

        public async Task<CashInDTO> Save(CashInDTO cashInDTO)
        {   
            CashIn cashIn = _mapper.MapperToEntity(cashInDTO);
            cashIn = await _service.Save(cashIn);
            return _mapper.MapperToDTO(cashIn);
        }
    }
}
