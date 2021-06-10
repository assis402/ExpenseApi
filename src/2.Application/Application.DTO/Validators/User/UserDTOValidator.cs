using FluentValidation;
using Presentation.Utils.Messages;
using Application.DTO;

namespace Application.DTO.Validators
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(c => c)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC011())

                .NotNull()
                .WithMessage(ExceptionMessages.EXC012());
            
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(UserDTO.Id)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(UserDTO.Id)));
            
            When(c => c.Id != null && c.Id.Length != 24, () => {
                RuleFor(c => c.Id)
                    .Empty()
                    .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(UserDTO.Id)));
            });

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
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(UserDTO.Password)))

                .MinimumLength(10)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(UserDTO.Password),10))

                .MaximumLength(30)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(UserDTO.Password),30));

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(UserDTO.Name)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(UserDTO.Name)))

                .MinimumLength(3)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(UserDTO.Name),3))

                .MaximumLength(180)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(UserDTO.Name),180));
        }
    }
}