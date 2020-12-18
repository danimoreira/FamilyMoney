using System.Collections.Generic;
using System.Linq;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Interfaces;
using FamilyMoney.Repository.Repositories;
using FamilyMoney.Service.Interfaces;

namespace FamilyMoney.Service.Services
{
    public class FamilyService : ServiceBase<Family>, IFamilyService
    {        
        private readonly IFamilyRepository _repository;

        public FamilyService(IFamilyRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}