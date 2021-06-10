using FluentValidation;
using Presentation.Utils.Messages;
using Application.DTO;

namespace Application.DTO.Validators
{
    public class CashOutDTOValidator : AbstractValidator<CashOutDTO>
    {
        public CashOutDTOValidator()
        {
            RuleFor(c => c)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC011())

                .NotNull()
                .WithMessage(ExceptionMessages.EXC012());
            
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(CashInDTO.Id)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(CashInDTO.Id)));
            
            When(c => c.Id != null && c.Id.Length != 24, () => {
                RuleFor(c => c.Id)
                    .Empty()
                    .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(CashInDTO.Id)));
            });

            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(CashInDTO.Description)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(CashInDTO.Description)))

                .MinimumLength(1)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(CashInDTO.Description),1))

                .MaximumLength(40)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(CashInDTO.Description),40));

            RuleFor(c => c.Month)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(CashInDTO.Month)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(CashInDTO.Month)))

                .LessThan(1)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(CashInDTO.Month),1))

                .GreaterThan(12)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(CashInDTO.Month),12));

            RuleFor(c => c.Value)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(CashInDTO.Value)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(CashInDTO.Value)))

                .LessThan(0.10)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(CashInDTO.Value),0.10))

                .GreaterThan(100000)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(CashInDTO.Value),100000));
            
            When(c => c.UserId != null && c.UserId.Length != 24, () => {
                RuleFor(c => c.Id)
                    .Empty()
                    .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(CashInDTO.UserId)));
            });
        }
    }
}