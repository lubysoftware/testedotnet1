namespace Luby.Core.Model.Validations
{
    using FluentValidation;
    public class DesenvolvedorValidation : AbstractValidator<Desenvolvedor>
    {
        public DesenvolvedorValidation()
        {
            RuleFor(p => p.Nome)
                .NotNullNotEmpy()
                .LengthMinMax(3, 255);
        }
    }
}