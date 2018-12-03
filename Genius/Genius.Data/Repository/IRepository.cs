namespace Genius.Data
{
    using System;
    using System.Linq;

    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeMembers);

        TEntity GetById(int id);

        TEntity Add(TEntity entity);

        void Delete(TEntity entity);

        void Save();
    }
}
