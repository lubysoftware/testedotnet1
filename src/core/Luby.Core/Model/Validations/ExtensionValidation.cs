namespace Luby.Core.Model.Validations
{
    using FluentValidation;
    public static class ExtensionValidation
    {
        public static IRuleBuilderOptions<TE, TV> NotNullNotEmpy<TE, TV>(this IRuleBuilder<TE, TV> rule)
            => rule.NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!")
                    .NotNull().WithMessage("O campo {PropertyName} é obrigatório!");

        public static IRuleBuilderOptions<TE, string> LengthMinMax<TE>(this IRuleBuilder<TE, string> rule, int min, int max)
            => rule.Length(min, max).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength}");
    }
}