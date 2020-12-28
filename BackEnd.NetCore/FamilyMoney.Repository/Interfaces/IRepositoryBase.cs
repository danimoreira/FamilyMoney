using FamilyMoney.Domain.Entities;
using System.Linq;

namespace FamilyMoney.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);
        void Save();
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);        
    }    
}