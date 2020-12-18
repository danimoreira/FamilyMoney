using FamilyMoney.Domain.Entities;

namespace FamilyMoney.Service.Interfaces
{
    public interface IMemberService : IServiceBase<Member>
    {
         Member Login(string user, string password);
    }
}