using Dapper.FluentMap.Dommel.Mapping;
using FamilyMoney.Domain.Entities;

namespace FamilyMoney.Repository.Mapping
{
    public class FinancialFlowMap : DommelEntityMap<FinancialFlow>
    {
        public FinancialFlowMap()
        {
            ToTable("financialflow");
            Map(x => x.Id).ToColumn("Id").IsKey();
            Map(x => x.Movement.DateMovement).ToColumn("DateMovement");
            Map(x => x.Movement.TypeMovement).ToColumn("TypeMovement");
            Map(x => x.Movement.TypePayment).ToColumn("TypePayment");
            Map(x => x.Movement.ProviderName).ToColumn("ProviderName");
            Map(x => x.IdMemberMovement).ToColumn("IdMemberMovement");
            Map(x => x.Movement.UrlPaymentVoucher).ToColumn("UrlPaymentVoucher");
            Map(x => x.Movement.ValueMovement).ToColumn("ValueMovement");
            Map(x => x.Movement.SituationMovement).ToColumn("SituationMovement");

            Map(x => x.DateCreate).ToColumn("DateCreate");
            Map(x => x.UserCreate).ToColumn("UserCreate");
            Map(x => x.DateLastUpdate).ToColumn("DateLastUpdate");
            Map(x => x.UserUpdate).ToColumn("UserUpdate");
            Map(x => x.Active).ToColumn("Active");
        }
    }
}