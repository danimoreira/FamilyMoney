using System.Collections.Generic;
using FamilyMoney.Domain.Entities;

namespace FamilyMoney.Service.Interfaces
{
    public interface ISavingsAccountService : IServiceBase<SavingsAccount>
    {
         IEnumerable<SavingsAccount> GetAllRegisterByFamily(int idFamily);
    }
}