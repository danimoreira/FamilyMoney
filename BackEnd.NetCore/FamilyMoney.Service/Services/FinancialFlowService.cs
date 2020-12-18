using System.Collections.Generic;
using System.Linq;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Interfaces;
using FamilyMoney.Repository.Repositories;
using FamilyMoney.Service.Interfaces;

namespace FamilyMoney.Service.Services
{
    public class FinancialFlowService : ServiceBase<FinancialFlow>, IFinancialFlowService
    {
        private readonly IFinancialFlowRepository _repository;
        public FinancialFlowService(IFinancialFlowRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<FinancialFlow> GetAllRegisterByFamily(int idFamily){
            var obj = this.GetAll().Where(x => x.IdFamily.Equals(idFamily)).ToList();
            return obj;
        }
    }
}