using System.Collections.Generic;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Interfaces;
using FamilyMoney.Repository.Repositories;
using FamilyMoney.Service.Interfaces;

namespace FamilyMoney.Service.Services
{
    public class MemberService : ServiceBase<Member>, IMemberService
    {
        private readonly IMemberRepository _repository;

        public MemberService(IMemberRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Member Login(string user, string password)
        {
            return _repository.Login(user, password);
        }
    }
}