using System.Collections.Generic;
using Application.DTO.Validators;
using Presentation.Utils;
using Presentation.Utils.Messages;

namespace Application.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(string id, string email, string password, string name, string role)
        {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
            Role = role;
        }

        public bool Validate()
        {
            List<string> Errors = new List<string>();
            
            var validator = new UserDTOValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                {
                    Errors.Add(error.ErrorMessage);
                }

                throw new AppException(ExceptionMessages.EXC014(), Errors);
            }

            return true;
        }
    }
}
