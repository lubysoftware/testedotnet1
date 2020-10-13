using FluentValidation;

namespace Luby.Core.Model.Validations
{
    public class ProjetoDesenvolvedoresValidation : AbstractValidator<ProjetoDesenvolvedores>
    {
        public ProjetoDesenvolvedoresValidation()
        {
            RuleFor(p => p.DtInicio)
                .NotNullNotEmpy();

            RuleFor(p => p.DtFim)
                .NotNullNotEmpy()
                .GreaterThan(p => p.DtInicio).WithMessage("O campo {PropetyName} deve ser maior que DtFim");

        }
    }
}