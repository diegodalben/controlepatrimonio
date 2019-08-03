using System.Collections.Generic;

namespace Patrimonio.Business.BusinessRules.Abstractions
{
    public interface IBusinessRulesFactory<TEntity>
    {
        IReadOnlyCollection<IBusinessRules<TEntity>> Create();
    }
}