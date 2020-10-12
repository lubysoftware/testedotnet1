namespace Luby.Core.Model.Validations
{
    using FluentValidation;
    public class ProjetoValidation : AbstractValidator<Projeto>
    {
        public ProjetoValidation()
        {
            RuleFor(p => p.DtFim)
                .NotNullNotEmpy();
            
            RuleFor(p => p.DtInicio)
                .NotNullNotEmpy();
        }
    }
}