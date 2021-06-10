using System;
using System.Collections.Generic;
using Application.DTO.Validators;
using Presentation.Utils;
using Presentation.Utils.Messages;

namespace Application.DTO
{
    public class CashOutDTO
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int Month { get; set; }
        public double Value { get; set; }
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }

        public CashOutDTO()
        {
        }

        public CashOutDTO(string id, string description, int month, double value, string userId, DateTime creationDate)
        {
            Id = id;
            Description = description;
            Month = month;
            Value = value;
            UserId = userId;
            CreationDate = creationDate;
        }

        public bool Validate()
        {
            List<string> Errors = new List<string>();
            
            var validator = new CashOutDTOValidator();
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
