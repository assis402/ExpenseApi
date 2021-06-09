using System.Collections.Generic;
using Application.DTO.Validators;
using Presentation.Utils;
using Presentation.Utils.Messages;

namespace Application.DTO
{
    public class DeleteCashInDTO
    {
        public string UserId { get; set; }
        public string CashInId { get; set; }

        public DeleteCashInDTO()
        {
        }

        public DeleteCashInDTO(string userId, string cashInId)
        {
            UserId = userId;
            CashInId = cashInId;
        }

        public bool Validate()
        {
            List<string> Errors = new List<string>();
            
            var validator = new DeleteCashInDTOValidator();
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