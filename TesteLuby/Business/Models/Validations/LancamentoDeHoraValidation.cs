using FluentValidation;

namespace Business.Models.Validations
{
    public class LancamentoDeHoraValidation : AbstractValidator<LancamentoDeHora>
    {
        public LancamentoDeHoraValidation()
        {
            RuleFor(p => p.HoraInicio)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.HoraFim)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}