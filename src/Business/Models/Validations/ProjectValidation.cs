using FluentValidation;

namespace Business.Models.Validations
{
    public class ProjectValidation : AbstractValidator<Project>
    {
        #region Constructor
        public ProjectValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser forncecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
        #endregion Constructor
    }
}
