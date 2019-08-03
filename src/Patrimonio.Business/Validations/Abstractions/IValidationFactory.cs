using System.Collections.Generic;
using FluentValidation;

namespace Patrimonio.Business.Validations.Abstractions
{
    public interface IValidationFactory<TEntity>
    {
        IReadOnlyCollection<IValidator<TEntity>> Create();
    }
}