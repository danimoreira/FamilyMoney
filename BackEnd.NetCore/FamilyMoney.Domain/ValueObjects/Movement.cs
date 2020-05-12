using System;
using FamilyMoney.Domain.Enums;

namespace FamilyMoney.Domain.ValueObjects
{
    public class Movement
    {
        public Movement(DateTime dateMovement, string description, string providerName, TypeMovementEnum typeMovement, TypePaymentEnum typePaymentEnum, Double valueMovement, string urlPaymentVoucher)
        {
            this.DateMovement = dateMovement;
            this.Description = description;
            this.ProviderName = providerName;
            this.TypeMovement = typeMovement;
            this.TypePayment = TypePayment;
            this.ValueMovement = valueMovement;
            this.UrlPaymentVoucher = urlPaymentVoucher;
            this.SituationMovement = SituationMovementEnum.None;
        }
        public DateTime DateMovement { get; private set; }
        public TypeMovementEnum TypeMovement { get; private set; }
        public TypePaymentEnum TypePayment { get; private set; }
        public string Description { get; private set; }
        public string ProviderName { get; private set; }
        public Double ValueMovement { get; private set; }
        public string UrlPaymentVoucher { get; private set; }
        public SituationMovementEnum SituationMovement { get; private set; }
    }
}