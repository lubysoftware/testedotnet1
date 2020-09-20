using FluentValidation;

namespace TimeManager.Application.Developers.ChangeDeveloperDetails
{
    public class ChangeDeveloperDetailsCommandValidator : AbstractValidator<ChangeDeveloperDetailsCommand>
    {
        public ChangeDeveloperDetailsCommandValidator()
        {
            RuleFor(v => v.Name)
                .MinimumLength(3)
                .NotEmpty();
        }
    }
}
