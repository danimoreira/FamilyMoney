using System.Collections.Generic;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Repositories;

namespace FamilyMoney.Service.Services
{
    public class SavingsAccountService
    {
        SavingsAccountRepository _repository;
        public SavingsAccountService()
        {
            _repository = new SavingsAccountRepository();
        }

        public int Create(SavingsAccount obj)
        {
            return _repository.Add(obj);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Update(SavingsAccount obj)
        {
            _repository.Update(obj);
        }

        public SavingsAccount GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<SavingsAccount> GetAll()
        {
            return _repository.GetAll();
        }
    }
}