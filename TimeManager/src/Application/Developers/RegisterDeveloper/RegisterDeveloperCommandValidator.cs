using FluentValidation;

namespace TimeManager.Application.Developers.RegisterDeveloper
{
    public class RegisterDeveloperCommandValidator : AbstractValidator<RegisterDeveloperCommand>
    {
        public RegisterDeveloperCommandValidator()
        {
            RuleFor(v => v.Name)
                .MinimumLength(3)
                .NotEmpty();
        }
    }
}
