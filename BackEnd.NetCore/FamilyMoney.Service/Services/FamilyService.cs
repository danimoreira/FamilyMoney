using System.Collections.Generic;
using System.Linq;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Repositories;

namespace FamilyMoney.Service.Services
{
    public class FamilyService
    {
        FamilyRepository _repository;

        public FamilyService()
        {
            _repository = new FamilyRepository();
        }

        public List<Family> GetAll()  {
            var obj = _repository.GetAll();
            return obj
            ;
        }

        public Family GetById(int id){
            var obj = _repository.GetById(id);
            return obj;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public int Create(Family obj)
        {
            return _repository.Add(obj);
        }

        public void Update(Family obj)
        {
            _repository.Update(obj);
        }

    }
}