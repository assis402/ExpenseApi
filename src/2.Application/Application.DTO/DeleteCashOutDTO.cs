using System.Collections.Generic;
using Application.DTO.Validators;
using Presentation.Utils;
using Presentation.Utils.Messages;

namespace Application.DTO
{
    public class DeleteCashOutDTO
    {
        public string UserId { get; set; }
        public string CashOutId { get; set; }

        public DeleteCashOutDTO()
        {
        }

        public DeleteCashOutDTO(string userId, string cashOutId)
        {
            UserId = userId;
            CashOutId = cashOutId;
        }

        public bool Validate()
        {
            List<string> Errors = new List<string>();
            
            var validator = new DeleteCashOutDTOValidator();
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