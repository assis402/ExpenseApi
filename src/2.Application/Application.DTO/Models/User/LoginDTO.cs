using System.Collections.Generic;
using Application.DTO.Validators;
using Presentation.Utils;
using Presentation.Utils.Messages;

namespace Application.DTO
{
    public class LoginDTO
    {
        public string Email { get; set; }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = CryptographyMD5.StringToMD5(value); }
        }

        public LoginDTO()
        {
        }

        public bool Validate()
        {
            List<string> Errors = new List<string>();
            
            var validator = new LoginDTOValidator();
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