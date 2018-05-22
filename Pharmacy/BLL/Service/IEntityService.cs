using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pharmacy.DAL.Models;

namespace Pharmacy.BLL.Service
{
    public interface IEntityService<T> : IService
     where T : BaseEntity
    {
        
        void Create(T entity);

        void Delete(T entity);

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate = null);

        T GetById(object id);

        void Update(T entity);
    }
}
