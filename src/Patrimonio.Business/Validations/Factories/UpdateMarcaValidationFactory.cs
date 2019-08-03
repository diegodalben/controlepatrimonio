using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentValidation;
using Patrimonio.Business.Entities;
using Patrimonio.Business.Repositories;
using Patrimonio.Business.Validations.Abstractions;
using Patrimonio.Business.Validations.Marca;

namespace Patrimonio.Business.Validations.Factories
{
    public sealed class UpdateMarcaValidationFactory : IValidationFactory<EMarca>
    {
        private readonly IMarcaRepository _repository;

        public UpdateMarcaValidationFactory(IMarcaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IReadOnlyCollection<IValidator<EMarca>> Create()
        {
            var validations = new List<IValidator<EMarca>>
            {
                new DataMustNotBeEmpty(),
                new NameMustNotExistInDb(_repository)
            };

            return new ReadOnlyCollection<IValidator<EMarca>>(validations);
        }
    }
}