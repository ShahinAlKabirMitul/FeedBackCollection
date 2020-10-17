using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using FeedBackCollection.Contracts;
using FeedBackCollection.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace FeedBackCollection.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ?
            RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().Where(expression).AsNoTracking()
                : RepositoryContext.Set<T>().Where(expression);

        public IQueryable<T> FindAllByCondition(Expression<Func<T, bool>> expression, int pageNo, int pageSize,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool trackChanges = false)
        {
            IQueryable<T> query = RepositoryContext.Set<T>().AsQueryable();
          
            if (include != null)
                query = include(query);

            if (expression != null)
                query = query.Where(expression);
            if (!trackChanges)
                query = query.AsNoTracking();
            var result = query.Skip((pageNo - 1) * pageSize).Take(pageSize);
            return result;
        }
           

        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
    }
}
