using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentValidation;
using Patrimonio.Business.Entities;
using Patrimonio.Business.Validations.Abstractions;
using Patrimonio.Business.Validations.Patrimonio;

namespace Patrimonio.Business.Validations.Factories
{
    public sealed class UpdatePatrimonioValidationFactory : IValidationFactory<EPatrimonio>
    {
        public IReadOnlyCollection<IValidator<EPatrimonio>> Create()
        {
            var validations = new List<IValidator<EPatrimonio>>
            {
                new DataMustNotBeEmpty()
            };

            return new ReadOnlyCollection<IValidator<EPatrimonio>>(validations);
        }
    }
}