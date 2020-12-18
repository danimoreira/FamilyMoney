using FamilyMoney.Domain.Entities;

namespace FamilyMoney.Repository.Interfaces
{
    public interface IMemberRepository : IRepositoryBase<Member>
    {
        Member Login(string username, string password);
    }
}