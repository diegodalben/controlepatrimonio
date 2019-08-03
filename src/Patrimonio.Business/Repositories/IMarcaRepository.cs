using Patrimonio.Business.Entities;

namespace Patrimonio.Business.Repositories
{
    public interface IMarcaRepository : IRepositoryBase<EMarca>
    {
        EMarca GetByName(string nome);
    }
}