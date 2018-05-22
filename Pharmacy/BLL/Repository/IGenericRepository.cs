using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PagedList;
using Pharmacy.Common.Enums;
using Pharmacy.DAL.Models;

namespace Pharmacy.BLL.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);

        IPagedList<T> Paginate(int pageIndex, int pageSize, Expression<Func<T, T>> keySelector,
            Expression<Func<T, bool>> predicate, OrderByType orderByType,
            params Expression<Func<T, object>>[] includeProperties);

        T Find(object id);

        T Add(T entity);

        T Delete(T entity);

        void Edit(T entity);

        void Save();

    }
}
