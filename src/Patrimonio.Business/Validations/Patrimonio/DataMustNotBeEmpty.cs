using FluentValidation;
using Patrimonio.Business.Entities;

namespace Patrimonio.Business.Validations.Patrimonio
{
    public sealed class DataMustNotBeEmpty : AbstractValidator<EPatrimonio>
    {
        public DataMustNotBeEmpty()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(e => e.Nome)
            .NotEmpty()
            .WithMessage("Nome do patrimônio deve ser inforado.");

            RuleFor(e => e.Marca.MarcaId)
            .NotEmpty()
            .WithMessage("Marca deve ser informado.");
        }
    }
}