using System;
using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Presentation.API.Token;
using Presentation.Utils;
using Presentation.Utils.Messages;

namespace Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserApplication _applicantion;
        

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] LoginDTO loginDTO){
            try
            {
                loginDTO.Validate();

                var login = _applicantion.Login(loginDTO);

                if (login != null)
                {
                    var Data = new
                    {
                        Token = _tokenGenerator.GenerateToken(login.Result),
                        TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                    };

                    return Ok(Responses.SuccessMessage(InformationMessages.INF002(),Data));
                }
                else
                    return StatusCode(401, Responses.UnauthorizedErrorMessage());
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