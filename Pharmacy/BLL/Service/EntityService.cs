using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pharmacy.BLL.Repository;
using Pharmacy.DAL;
using Pharmacy.DAL.Models;

namespace Pharmacy.BLL.Service
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;

        protected EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual void Create(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public T GetById(object id)
        {
            return _repository.Find(id);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _repository.Edit(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            return _repository.GetAll(includeProperties);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindAll(predicate);
        }

    }
}
