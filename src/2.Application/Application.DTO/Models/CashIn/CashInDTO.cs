using System;
using System.Collections.Generic;
using Application.DTO.Validators;
using Presentation.Utils;
using Presentation.Utils.Messages;

namespace Application.DTO
{
    public class CashInDTO
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int Month { get; set; }
        public double Value { get; set; }
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }

        public CashInDTO()
        {
        }

        public bool Validate()
        {
            List<string> Errors = new List<string>();
            
            var validator = new CashInDTOValidator();
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
