using System.Collections.Generic;

namespace Application.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public UserDTO()
        {
        }   
    }
}