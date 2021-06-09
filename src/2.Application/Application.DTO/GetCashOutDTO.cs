using System.Collections.Generic;
using Application.DTO.Validators;
using Presentation.Utils;
using Presentation.Utils.Messages;

namespace Application.DTO
{
    public class GetCashOutDTO
    {
        public string UserId { get; set; }
        public int Month { get; set; }

        public GetCashOutDTO()
        {
        }

        public GetCashOutDTO(string userId, int mounth)
        {
            UserId = userId;
            Month = mounth;
        }

        public bool Validate()
        {
            List<string> Errors = new List<string>();
            
            var validator = new GetCashOutDTOValidator();
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