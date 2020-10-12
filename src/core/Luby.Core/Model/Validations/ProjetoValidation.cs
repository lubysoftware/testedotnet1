namespace Luby.Core.Model.Validations
{
    using FluentValidation;
    public class ProjetoValidation : AbstractValidator<Projeto>
    {
        public ProjetoValidation()
        {
            RuleFor(p => p.Descricao)
                .NotNullNotEmpy()
                .LengthMinMax(3, 255);
        }
    }
}