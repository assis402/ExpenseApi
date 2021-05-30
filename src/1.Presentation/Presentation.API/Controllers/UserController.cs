using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTO;
using System.Threading.Tasks;

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
            var user = await _applicantion.Save(userDTO);
            
            return StatusCode(201, "User adicionado com sucesso");
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var Users = await _applicantion.GetAll();
            
            return Ok(Users);
        }
    }
}
