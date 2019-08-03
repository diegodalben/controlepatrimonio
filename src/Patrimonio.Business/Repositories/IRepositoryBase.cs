using System.Collections.Generic;

namespace Patrimonio.Business.Repositories
{
    public interface IRepositoryBase<TEntity>
    {
        int Create(TEntity entity);
        int Update(TEntity entity);
        int Delete(object id);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
    }
}