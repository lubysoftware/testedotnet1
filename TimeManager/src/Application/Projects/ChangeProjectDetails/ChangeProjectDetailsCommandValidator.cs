using FluentValidation;

namespace TimeManager.Application.Projects.ChangeProjectDetails
{
    public class ChangeProjectDetailsCommandValidator : AbstractValidator<ChangeProjectDetailsCommand>
    {
        public ChangeProjectDetailsCommandValidator()
        {
            RuleFor(v => v.Name)
                .MinimumLength(3)
                .NotEmpty();
        }
    }
}
