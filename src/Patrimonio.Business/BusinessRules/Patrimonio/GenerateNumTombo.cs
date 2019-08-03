using System;
using System.Text.RegularExpressions;
using Patrimonio.Business.BusinessRules.Abstractions;
using Patrimonio.Business.Entities;

namespace Patrimonio.Business.BusinessRules.Patrimonio
{
    public sealed class GenerateNumTombo : IBusinessRules<EPatrimonio>
    {
        public void Apply(EPatrimonio entity)
        {
            var id = Guid.NewGuid();
            var sequence = String.Join("", Regex.Split(id.ToString(), @"[^\d]"));
            entity.NumTombo = Convert.ToInt32($"{sequence:D9}");
        }
    }
}