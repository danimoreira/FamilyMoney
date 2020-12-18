using System.Collections.Generic;
using System.Linq;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Interfaces;
using FamilyMoney.Repository.Repositories;
using FamilyMoney.Service.Interfaces;

namespace FamilyMoney.Service.Services
{
    public class SavingsAccountService : ServiceBase<SavingsAccount>, ISavingsAccountService
    {
        private readonly ISavingsAccountRepository _repository;
        public SavingsAccountService(ISavingsAccountRepository repository) : base(repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<SavingsAccount> GetAllRegisterByFamily(int idFamily){
            var obj = this.GetAll().Where(x => x.IdFamily.Equals(idFamily)).ToList();
            return obj;
        }
    }
}