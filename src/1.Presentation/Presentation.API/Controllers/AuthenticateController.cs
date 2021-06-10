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
        private readonly IConfiguration configuration;
        private readonly ITokenGenerator tokenGenerator;
        private readonly IUserApplicationService userApplicationService;
        private readonly IClinicalUnitApplicationService clinicalUnitApplicationService;

        public AuthenticateController(IConfiguration configuration, ITokenGenerator tokenGenerator, IUserApplicationService userApplicationService, IClinicalUnitApplicationService clinicalUnitApplicationService)
        {
            this.configuration = configuration;
            this.tokenGenerator = tokenGenerator;
            this.userApplicationService = userApplicationService;
            this.clinicalUnitApplicationService = clinicalUnitApplicationService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] JsonPost inputJson){
            try
            {
                inputJson.Validate();
                
                var clinicalUnit = clinicalUnitApplicationService.GetClinicalUnitById(inputJson.ClinicalUnitId);

                if(clinicalUnit == null)
                    return BadRequest(Responses.ErrorMessage(string.Format(ExceptionMessages.EXC016(),"Clinical Unit")));

                UserDTO userDTO = inputJson.JsonPostToDTO();

                var user = userApplicationService.GetUserToLogin(userDTO);

                if (user != null)
                {
                    var Data = new
                    {
                        Token = tokenGenerator.GenerateToken(user.Result),
                        TokenExpires = DateTime.UtcNow.AddHours(int.Parse(configuration["Jwt:HoursToExpire"]))
                    };

                    return Ok(Responses.SuccessMessage(InformationMessages.INF002(),Data));
                }
                else
                    return StatusCode(401, Responses.UnauthorizedErrorMessage());
            }
            catch(InputJsonException ex)
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