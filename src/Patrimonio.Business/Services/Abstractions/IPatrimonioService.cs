using System.Collections.Generic;
using Patrimonio.Business.Dto;
using Patrimonio.Business.Entities;

namespace Patrimonio.Business.Services.Abstractions
{
    public interface IPatrimonioService
    {
        ResponseBag<int> Create(EPatrimonio entity);
        ResponseBag<int> Update(EPatrimonio entity);
        ResponseBag<int> Delete(long patrimonioId);
        ResponseBag<IEnumerable<EPatrimonio>> GetAll();
        ResponseBag<EPatrimonio> GetById(long patrimonioId);
        ResponseBag<IEnumerable<EPatrimonio>> GetByMarca(int marcaId);
    }
}