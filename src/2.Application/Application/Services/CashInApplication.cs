using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Core.Services;
using Domain.Entities;

namespace Application.Services
{
    public class CashInApplication : ICashInApplication
    {
        private readonly IBaseService<CashIn> _service;
        private readonly ICashInMapper _mapper;

        public CashInApplication(IBaseService<CashIn> service, ICashInMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ICollection<CashIn>> FindAll()
        {
            return await _service.FindAll();
        }

        public async Task<CashIn> Save(CashIn cashIn)
        {
            return await _service.Save(cashIn);
        }
    }
}
