namespace Patrimonio.Business.BusinessRules.Abstractions
{
    public interface IBusinessRules<TEntity>
    {
        void Apply(TEntity entity);
    }
}