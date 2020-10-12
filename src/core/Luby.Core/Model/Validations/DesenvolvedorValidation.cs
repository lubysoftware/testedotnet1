namespace Luby.Core.Model.Validations
{
    using FluentValidation;
    public class DesenvolvedorValidation : AbstractValidator<Desenvolvedor>
    {
        public DesenvolvedorValidation()
        {
            RuleFor(p => p.Nome)
                .NotNullNotEmpy()
                .Length(3, 255).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength}");
        }
    }
}