using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTO;
using System.Threading.Tasks;
using Presentation.Utils;
using Presentation.Utils.Messages;

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
        public async Task<ActionResult> Post([FromBody] UserDTO userDTO)
        {
            try
            {
                var user = await _applicantion.Save(userDTO);
                
                return StatusCode(201, Responses.SuccessMessage(string.Format(InformationMessages.INF001(), "User"), user));
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
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserDTO userDTO)
        {
            try 
            {
                var user = await _applicantion.Put(userDTO);
                
                return StatusCode(201, Responses.SuccessMessage(string.Format(InformationMessages.INF001(), "User"), user));
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] UserDTO userDTO)
        {
            try 
            {
                var user = await _applicantion.Save(userDTO);
                
                return StatusCode(201, Responses.SuccessMessage(string.Format(InformationMessages.INF001(), "User"), user));
            }
        }
    }
}
