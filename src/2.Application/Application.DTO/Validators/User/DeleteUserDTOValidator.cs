using FluentValidation;
using Presentation.Utils.Messages;
using Application.DTO;

namespace Application.DTO.Validators
{
    public class DeleteUserDTOValidator : AbstractValidator<DeleteUserDTO>
    {
        public DeleteUserDTOValidator()
        {
            RuleFor(c => c)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC011())

                .NotNull()
                .WithMessage(ExceptionMessages.EXC012());
            
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(DeleteUserDTO.UserId)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(DeleteUserDTO.UserId)));
            
            When(c => c.UserId != null && c.UserId.Length != 24, () => {
                RuleFor(c => c.UserId)
                    .Empty()
                    .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(DeleteUserDTO.UserId)));
            });
        }
    }
}