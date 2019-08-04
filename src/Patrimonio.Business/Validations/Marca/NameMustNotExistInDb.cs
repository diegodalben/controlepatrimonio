using System;
using FluentValidation;
using Patrimonio.Business.Entities;
using Patrimonio.Business.Repositories;

namespace Patrimonio.Business.Validations.Marca
{
    public sealed class NameMustNotExistInDb : AbstractValidator<EMarca>
    {
        private readonly IMarcaRepository _repository;

        public NameMustNotExistInDb(IMarcaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            RuleFor(e => e.Nome)
            .Must(ExistsInDb)
            .WithMessage("Nome da marca informada já cadastrado.");
        }

        private bool ExistsInDb(string nome)
        {
            var entity = _repository.GetByName(nome);
            return entity == null;
        }
    }
}