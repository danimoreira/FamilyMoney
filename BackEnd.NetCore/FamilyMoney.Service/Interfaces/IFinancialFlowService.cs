using System.Collections.Generic;
using FamilyMoney.Domain.Entities;

namespace FamilyMoney.Service.Interfaces
{
    public interface IFinancialFlowService : IServiceBase<FinancialFlow>
    {
        IEnumerable<FinancialFlow> GetAllRegisterByFamily(int idFamily);
    }
}