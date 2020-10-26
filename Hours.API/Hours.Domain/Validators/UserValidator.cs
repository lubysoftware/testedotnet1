using FluentValidation;
using Hours.Domain.Entities;

namespace Hours.Domain.Validators
{
    public class UserValidator : AbstractValidator<UsersEntity>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).Length(2, 50).WithMessage("Must be between 2 and 50 characters.");           
            RuleFor(x => x.Email).EmailAddress().NotNull();
            RuleFor(x => x.Senha).NotEmpty().NotNull();
        }
    }
}
