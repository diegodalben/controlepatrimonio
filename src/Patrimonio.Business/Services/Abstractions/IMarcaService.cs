using System.Collections.Generic;
using Patrimonio.Business.Dto;
using Patrimonio.Business.Entities;

namespace Patrimonio.Business.Services.Abstractions
{
    public interface IMarcaService
    {
        ResponseBag<NoContent> Create(EMarca entity);
        ResponseBag<NoContent> Update(EMarca entity);
        ResponseBag<NoContent> Delete(int marcaId);
        ResponseBag<IEnumerable<EMarca>> GetAll();
        ResponseBag<EMarca> GetById(int marcaId);
    }
}