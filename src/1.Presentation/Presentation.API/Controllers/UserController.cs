using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTO;
using System.Threading.Tasks;
using Presentation.Utils;
using Presentation.Utils.Messages;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _applicantion;

        public UserController(IUserApplication applicantion)
        {
            _applicantion = applicantion;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] UserDTO userDTO)
        {
            try
            {
                var user = await _applicantion.Save(userDTO);
                
                return StatusCode(201, Responses.SuccessMessage(string.Format(InformationMessages.INF001(), "User"), user));
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
        public async Task<ActionResult> Get()
        {
            try
            {
                var Users = await _applicantion.GetAll();
            
                return Ok(Users);
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
        [Authorize]
        public async Task<ActionResult> Put([FromBody] UserDTO userDTO)
        {
            try 
            {
                await _applicantion.Update(userDTO);
                
                return Ok(Responses.SuccessMessage(string.Format(InformationMessages.INF003(), "User")));
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
        [Authorize]
        public async Task<ActionResult> Delete(string userId)
        {
            try 
            {
                DeleteUserDTO deleteUserDTO = new DeleteUserDTO(userId);

                await _applicantion.Delete(deleteUserDTO);
                
                return Ok(Responses.SuccessMessage(string.Format(InformationMessages.INF004(), "User")));
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
