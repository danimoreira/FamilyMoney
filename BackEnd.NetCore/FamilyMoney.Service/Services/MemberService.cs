using System.Collections.Generic;
using FamilyMoney.Domain.Entities;
using FamilyMoney.Repository.Repositories;

namespace FamilyMoney.Service.Services
{
    public class MemberService
    {
        MemberRepository _repository;

        public MemberService()
        {
            _repository = new MemberRepository();
        }
        
        public List<Member> GetAll()  {
            var obj = _repository.GetAll();
            return obj
            ;
        }

        public Member GetById(int id){
            var obj = _repository.GetById(id);
            return obj;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public int Create(Member obj)
        {
            return _repository.Add(obj);
        }

        public void Update(Member obj)
        {
            _repository.Update(obj);
        }

        public bool Login(string user, string password)
        {
            return _repository.Login(user, password);
        }
    }
}