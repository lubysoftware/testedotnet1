namespace Luby.Core.Model.Validations
{
    using FluentValidation;
    public static class ExtensionValidation
    {
        public static IRuleBuilderOptions<TE, TV> NotNullNotEmpy<TE, TV>(this IRuleBuilder<TE, TV> rule)
            => rule.NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!")
                    .NotNull().WithMessage("O campo {PropertyName} é obrigatório!");
    }
}