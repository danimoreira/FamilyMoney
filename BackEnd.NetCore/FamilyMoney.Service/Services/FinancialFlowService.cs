using System.Collections.Generic;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Repositories;

namespace FamilyMoney.Service.Services
{
    public class FinancialFlowService
    {
        FinancialFlowRepository _repository;
        public FinancialFlowService()
        {
            _repository = new FinancialFlowRepository();
        }

        public int Create(FinancialFlow obj)
        {
            return _repository.Add(obj);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Update(FinancialFlow obj)
        {
            _repository.Update(obj);
        }

        public FinancialFlow GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<FinancialFlow> GetAll()
        {
            return _repository.GetAll();
        }
    }
}