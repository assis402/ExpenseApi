using FluentValidation;
using Presentation.Utils.Messages;
using Application.DTO;

namespace Application.DTO.Validators
{
    public class DeleteCashOutDTOValidator : AbstractValidator<DeleteCashOutDTO>
    {
        public DeleteCashOutDTOValidator()
        {
            RuleFor(c => c)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC011())

                .NotNull()
                .WithMessage(ExceptionMessages.EXC012());
            
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(DeleteCashOutDTO.UserId)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(DeleteCashOutDTO.UserId)));
            
            When(c => c.UserId != null && c.UserId.Length != 24, () => {
                RuleFor(c => c.UserId)
                    .Empty()
                    .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(DeleteCashOutDTO.UserId)));
            });

            RuleFor(c => c.CashOutId)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(DeleteCashOutDTO.CashOutId)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(DeleteCashOutDTO.CashOutId)));
            
            When(c => c.CashOutId != null && c.CashOutId.Length != 24, () => {
                RuleFor(c => c.CashOutId)
                    .Empty()
                    .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(DeleteCashOutDTO.CashOutId)));
            });
        }
    }
}