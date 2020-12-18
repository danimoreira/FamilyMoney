using System.Collections.Generic;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Interfaces;
using FamilyMoney.Service.Interfaces;

namespace FamilyMoney.Service.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : BaseEntity
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual int Create(TEntity obj)
        {
            return _repository.Add(obj);
        }

        public virtual void Delete(int id)
        {
            _repository.Delete(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual void Update(TEntity obj)
        {
             _repository.Update(obj);
        }
    }
}