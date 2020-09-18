using FluentValidation;

namespace TimeManager.Application.Projects.Commands.Create
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(3)
                .NotEmpty();
        }
    }
}
