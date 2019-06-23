using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FiiApp.Data.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        TEntity GetById(int id);

        IQueryable<TEntity> Query();

        int Count();

        int Count(Expression<Func<TEntity, bool>> where);

        List<TEntity> GetMany(Expression<Func<TEntity, bool>> where);

        void RefreshEntity(TEntity entity);
    }
}
