using System.Collections.Generic;
using Patrimonio.Business.Dto;
using Patrimonio.Business.Entities;

namespace Patrimonio.Business.Services.Abstractions
{
    public interface IPatrimonioService
    {
        ResponseBag<NoContent> Create(EPatrimonio entity);
        ResponseBag<NoContent> Update(EPatrimonio entity);
        ResponseBag<NoContent> Delete(long patrimonioId);
        ResponseBag<IEnumerable<EPatrimonio>> GetAll();
        ResponseBag<EPatrimonio> GetById(long patrimonioId);
        ResponseBag<IEnumerable<EPatrimonio>> GetByMarca(int marcaId);
    }
}