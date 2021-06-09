using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTO;
using System.Threading.Tasks;
using System;
using Presentation.Utils;
using Presentation.Utils.Messages;

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
            try
            {
                cashInDTO.Validate();
                var cashIn = await _applicantion.Save(cashInDTO);

                return StatusCode(201, Responses.SuccessMessage(string.Format(InformationMessages.INF001(), "CashIn"), cashIn));
            }
            catch(AppException ex)
            {
                return BadRequest(Responses.ErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get(string userId, int month)
        {
            try 
            {
                GetCashInDTO getCashInDTO = new GetCashInDTO(userId, month);

                getCashInDTO.Validate();
                var cashIns = await _applicantion.GetAllByUserIdAndMounth(getCashInDTO);

                return Ok(Responses.SuccessMessage(cashIns));
            }
            catch(AppException ex)
            {
                return BadRequest(Responses.ErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CashInDTO cashInDTO)
        {
            try 
            {
                cashInDTO.Validate();
                await _applicantion.Update(cashInDTO);
                
                return Ok(Responses.SuccessMessage(string.Format(InformationMessages.INF003(), "CashIn")));
            }
            catch(AppException ex)
            {
                return BadRequest(Responses.ErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteCashInDTO deleteCashInDTO)
        {
            try
            {
                DeleteCashOutDTO getCashOutDTO = new DeleteCashOutDTO(deleteCashInDTO.UserId, deleteCashInDTO.CashInId);

                await _applicantion.Delete(deleteCashInDTO);

                return Ok(Responses.SuccessMessage(string.Format(InformationMessages.INF004(), "CashIn")));
            }
            catch(AppException ex)
            {
                return BadRequest(Responses.ErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
