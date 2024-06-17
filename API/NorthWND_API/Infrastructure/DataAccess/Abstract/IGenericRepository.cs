using System.Linq.Expressions;

namespace Infrastructure.DataAccess.Abstract
{
    public interface IGenericRepository<TEntity>
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params string[] includeList);
        TEntity Get(Expression<Func<TEntity, bool>> filter = null, params string[] includeList);

        TEntity Insert(TEntity entity);
        void Delete(TEntity entity);
        //int Delete(TEntity entity);
        TEntity Update(TEntity entity);

    }
}
