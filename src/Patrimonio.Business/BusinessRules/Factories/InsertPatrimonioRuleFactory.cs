using System.Collections.Generic;
using System.Collections.ObjectModel;
using Patrimonio.Business.BusinessRules.Abstractions;
using Patrimonio.Business.BusinessRules.Patrimonio;
using Patrimonio.Business.Entities;

namespace Patrimonio.Business.BusinessRules.Factories
{
    public sealed class InsertPatrimonioRuleFactory : IBusinessRulesFactory<EPatrimonio>
    {
        public IReadOnlyCollection<IBusinessRules<EPatrimonio>> Create()
        {
            var rules = new List<IBusinessRules<EPatrimonio>>
            {
                new GenerateNumTombo()
            };

            return new ReadOnlyCollection<IBusinessRules<EPatrimonio>>(rules);
        }
    }
}