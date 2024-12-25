using ECommerceApp.Server.Controllers.Users.Dtos;
using FluentValidation;

namespace ECommerceApp.Server.Controllers.Users.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(dto => dto.Email).EmailAddress().WithMessage("Invalid email.");
            RuleFor(dto => dto.Password).NotEmpty().WithMessage("Invalid password.");
        }

    }
}
