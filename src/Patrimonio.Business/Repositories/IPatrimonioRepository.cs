using System.Collections.Generic;
using Patrimonio.Business.Entities;

namespace Patrimonio.Business.Repositories
{
    public interface IPatrimonioRepository : IRepositoryBase<EPatrimonio>
    {
        IEnumerable<EPatrimonio> GetByMarca(int marcaId);
    }
}