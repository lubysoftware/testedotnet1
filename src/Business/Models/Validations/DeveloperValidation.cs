using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models.Validations
{
    /// <summary>
    /// Classe de validação do objeto desenvolvedor
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 21/09/2020
    /// </remarks>
    public class DeveloperValidation : AbstractValidator<Developer>
    {
        #region Constructor
        public DeveloperValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser forncecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caractres");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caractres");

            RuleFor(c => c.Uf)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 2).WithMessage("O Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caractres");
        }
        #endregion Constructor
    }
}
