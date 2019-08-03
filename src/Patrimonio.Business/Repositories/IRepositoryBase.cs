using System.Collections.Generic;

namespace Patrimonio.Business.Repositories
{
    public interface IRepositoryBase<TEntity>
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
    }
}