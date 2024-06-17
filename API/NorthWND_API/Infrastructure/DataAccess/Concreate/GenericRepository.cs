using Infrastructure.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Concreate
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
      where TEntity : class, new()
      where TContext : DbContext, new()
    {
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                EntityEntry<TEntity> deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null, params string[] includeList)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> dbSet = context.Set<TEntity>();
                if (filter != null)
                {
                    dbSet = dbSet.Where(filter);
                }
                if (includeList != null)
                {
                    foreach (var item in includeList)
                    {
                        dbSet = dbSet.Include(item);
                    }
                }
                return dbSet.SingleOrDefault();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params string[] includeList)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> dbSet = context.Set<TEntity>();
                if (filter !=null)
                {
                    dbSet = dbSet.Where(filter);
                }
                if (includeList != null)
                {
                    foreach (var item in includeList)
                    {
                        dbSet = dbSet.Include(item);
                    }
                }
                return dbSet.ToList();
            }
        }

        public TEntity Insert(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                EntityEntry<TEntity> addedEntity = context.Set<TEntity>().Add(entity);
                context.SaveChanges();
                return addedEntity.Entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                EntityEntry<TEntity> updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return updatedEntity.Entity;  
            }
        }
    }
}
