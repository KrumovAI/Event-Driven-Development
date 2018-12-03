namespace Genius.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> entities;
        private readonly DbContext context;

        public Repository(GeniusDbContext context)
        {
            this.entities = context.Set<TEntity>();
            this.context = context;
        }
        
        public IQueryable<TEntity> GetAll()
        {
            return this.entities;
        }

        public IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeMembers)
        {
            return includeMembers(this.entities);
        }

        public TEntity GetById(int id)
        {
            return this.entities.Find(id);
        }

        public TEntity Add(TEntity entity)
        {
            return this.entities.Add(entity).Entity;
        }

        public void Delete(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
