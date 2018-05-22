using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PagedList;
using Pharmacy.Common.Enums;
using Pharmacy.DAL.Models;

namespace Pharmacy.BLL.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
     where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        protected GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            return (includeProperties.Length == 0)
                ? _dbSet
                : includeProperties.Aggregate(_dbSet.AsQueryable(), (current, includeProperty) => current.Include(includeProperty));
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return (predicate == null)
                ? _dbSet.AsEnumerable()
                : _dbSet.Where(predicate).AsEnumerable();
        }

        public IPagedList<T> Paginate(int pageIndex, int pageSize, Expression<Func<T, T>> keySelector,
            Expression<Func<T, bool>> predicate, OrderByType orderByType,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var queryable = (orderByType == OrderByType.Ascending)
                ? GetAll(includeProperties).OrderBy(keySelector)
                : GetAll(includeProperties).OrderByDescending(keySelector);
            var paginatedList = (predicate == null)
                ? queryable.ToPagedList(pageIndex, pageSize)
                : queryable.Where(predicate).ToPagedList(pageIndex, pageSize);

            return paginatedList;
        }

        public T Find(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual T Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

    }
}
