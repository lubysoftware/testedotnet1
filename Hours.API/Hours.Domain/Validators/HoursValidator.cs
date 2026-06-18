using FluentValidation;
using Hours.Domain.Entities;

namespace Hours.Domain.Validators
{
    public class HoursValidator : AbstractValidator<HoursEntity>
    {
        public HoursValidator()
        {
            RuleFor(x => x.Developer).Length(2, 30).WithMessage("Must be between 2 and 30 characters.");           
            RuleFor(x => x.StartDate).NotNull();
            RuleFor(x => x.EndDate).NotNull();
            RuleFor(d => d.EndDate).GreaterThanOrEqualTo(d => d.StartDate).WithMessage("End date less than Start date");
        }
    }
}
