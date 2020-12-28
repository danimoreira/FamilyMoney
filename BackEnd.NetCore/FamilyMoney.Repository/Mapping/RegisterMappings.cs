using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using FamilyMoney.Repository.Mapping;

namespace FamilyMoney.Repository
{
    public class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new FamilyMap());
                config.AddMap(new MemberMap());
                config.AddMap(new SavingsAccountMap());
                config.AddMap(new FinancialFlowMap());
                config.ForDommel();
            });
        }
    }
}