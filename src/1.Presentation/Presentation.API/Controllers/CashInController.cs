using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTO;
using System.Threading.Tasks;

namespace Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CashInController : ControllerBase
    {

        private readonly ICashInApplication _applicantion;

        public CashInController(ICashInApplication applicantion)
        {
            _applicantion = applicantion;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CashInDTO cashInDTO)
        {
            var cashIn = await _applicantion.Save(cashInDTO);
            
            return StatusCode(201, "CashIn adicionado com sucesso");
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var CashIns = await _applicantion.GetAll();
            
            return Ok(CashIns);
        }
    }
}
