using FluentValidation;

namespace TimeManager.Application.Projects.RegisterProject
{
    public class RegisterProjectCommandValidator : AbstractValidator<RegisterProjectCommand>
    {
        public RegisterProjectCommandValidator()
        {
            RuleFor(v => v.Name)
                .MinimumLength(3)
                .NotEmpty();
        }
    }
}
