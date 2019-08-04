using FluentValidation;
using Patrimonio.Business.Entities;

namespace Patrimonio.Business.Validations.Marca
{
    public sealed class DataMustNotBeEmpty : AbstractValidator<EMarca>
    {
        public DataMustNotBeEmpty()
        {
            RuleFor(e => e.Nome)
            .NotEmpty()
            .WithMessage("Nome da marca deve ser informado.");
        }
    }
}