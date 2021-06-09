using FluentValidation;
using Presentation.Utils.Messages;
using Application.DTO;

namespace Application.DTO.Validators
{
    public class DeleteCashInDTOValidator : AbstractValidator<DeleteCashInDTO>
    {
        public DeleteCashInDTOValidator()
        {
            RuleFor(c => c)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC011())

                .NotNull()
                .WithMessage(ExceptionMessages.EXC012());
            
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(DeleteCashInDTO.UserId)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(DeleteCashInDTO.UserId)));
            
            When(c => c.UserId != null && c.UserId.Length != 24, () => {
                RuleFor(c => c.UserId)
                    .Empty()
                    .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(DeleteCashInDTO.UserId)));
            });

            RuleFor(c => c.CashInId)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(DeleteCashInDTO.CashInId)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(DeleteCashInDTO.CashInId)));
            
            When(c => c.CashInId != null && c.CashInId.Length != 24, () => {
                RuleFor(c => c.CashInId)
                    .Empty()
                    .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(DeleteCashInDTO.CashInId)));
            });
        }
    }
}