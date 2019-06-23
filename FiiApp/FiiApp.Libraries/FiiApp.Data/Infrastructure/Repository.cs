using FiiApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FiiApp.Data.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> dbset;

        public Repository(FiiAppContext context)
        {
            this.context = context;
            dbset = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbset.Add(entity);
        }

        public void Update(TEntity entity)
        {
            dbset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            dbset.Remove(entity);
        }

        public TEntity GetById(int id)
        {
            return dbset.Find(id);
        }

        public IQueryable<TEntity> Query()
        {
            return dbset.AsQueryable();
        }

        public int Count()
        {
            return dbset.Count();
        }

        public int Count(Expression<Func<TEntity, bool>> where)
        {
            return dbset.Count(where);
        }

        public List<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        public void RefreshEntity(TEntity entity)
        {
            context.Entry(entity).Reload();
        }
    }
}
