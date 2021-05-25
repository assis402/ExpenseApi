using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTO;

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
        public ActionResult Post([FromBody] CashInDTO cashInDTO)
        {
            var cashIn = _applicantion.Save(cashInDTO);
            
            return StatusCode(201, "CashIn adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult Get()
        {
            var CashIns = _applicantion.FindAll();
            
            return Ok(CashIns);
        }
    }
}
