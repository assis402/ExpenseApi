using System.Collections.Generic;
using Application.DTO.Validators;
using Presentation.Utils;
using Presentation.Utils.Messages;

namespace Application.DTO
{
    public class DeleteUserDTO
    {
        public string UserId { get; set; }

        public DeleteUserDTO()
        {
        }

        public DeleteUserDTO(string userId)
        {
            UserId = userId;
        }

        public bool Validate()
        {
            List<string> Errors = new List<string>();
            
            var validator = new DeleteUserDTOValidator();
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