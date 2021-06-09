using FluentValidation;
using Presentation.Utils.Messages;
using Application.DTO;

namespace Application.DTO.Validators
{
    public class GetCashInDTOValidator : AbstractValidator<GetCashInDTO>
    {
        public GetCashInDTOValidator()
        {
            RuleFor(c => c)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC011())

                .NotNull()
                .WithMessage(ExceptionMessages.EXC012());
            
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(CashInDTO.Id)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(CashInDTO.Id)));
            
            When(c => c.UserId != null && c.UserId.Length != 24, () => {
                RuleFor(c => c.UserId)
                    .Empty()
                    .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(CashInDTO.Id)));
            });

            RuleFor(c => c.Month)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(CashInDTO.Month)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(CashInDTO.Month)))

                .LessThan(1)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(CashInDTO.Month),1))

                .GreaterThan(12)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(CashInDTO.Month),12));
        }
    }
}