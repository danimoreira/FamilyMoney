using System.Collections.Generic;
using FamilyMoney.Domain.Entities;

namespace FamilyMoney.Service.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();        
        TEntity GetById(int id);
        void Delete(int id);
        int Create(TEntity obj);
        void Update(TEntity obj);
    }
}