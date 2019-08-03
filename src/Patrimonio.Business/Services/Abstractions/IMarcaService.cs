using System.Collections.Generic;
using Patrimonio.Business.Dto;
using Patrimonio.Business.Entities;

namespace Patrimonio.Business.Services.Abstractions
{
    public interface IMarcaService
    {
        ResponseBag<int> Create(EMarca entity);
        ResponseBag<int> Update(EMarca entity);
        ResponseBag<int> Delete(int marcaId);
        ResponseBag<IEnumerable<EMarca>> GetAll();
        ResponseBag<EMarca> GetById(int marcaId);
    }
}