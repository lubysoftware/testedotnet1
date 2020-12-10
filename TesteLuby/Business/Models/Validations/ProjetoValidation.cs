using FluentValidation;

namespace Business.Validations
{
    public class ProjetoValidation : AbstractValidator<Projeto>
    {
        public ProjetoValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}