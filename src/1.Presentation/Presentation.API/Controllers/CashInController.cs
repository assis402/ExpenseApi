using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTO;
using System.Threading.Tasks;
using System;

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
        public async Task<ActionResult> Get(string userId, int month)
        {
            var CashIns = await _applicantion.GetAllByUserIdAndMounth(userId, month);
            
            return Ok(CashIns);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CashInDTO cashInDTO)
        {
            await _applicantion.Update(cashInDTO);
            
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string userId, string cashInId)
        {
            await _applicantion.Delete(userId, cashInId);
            
            return Ok();
        }
    }
}
