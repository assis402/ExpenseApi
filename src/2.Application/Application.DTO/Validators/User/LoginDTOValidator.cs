using Application.DTO;
using FluentValidation;
using Presentation.Utils.Messages;

namespace Application.DTO.Validators
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(c => c)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC011())

                .NotNull()
                .WithMessage(ExceptionMessages.EXC012());

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(UserDTO.Email)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(UserDTO.Email)))

                .MinimumLength(6)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(UserDTO.Email),6))

                .MaximumLength(180)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(UserDTO.Email),180))

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(UserDTO.Email)));

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(UserDTO.Password)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(UserDTO.Password)));
        }
    }
}