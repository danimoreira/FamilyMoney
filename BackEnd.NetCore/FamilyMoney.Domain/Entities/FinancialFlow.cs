using System;
using FamilyMoney.Domain.Enums;
using FamilyMoney.Domain.ValueObjects;

namespace FamilyMoney.API.Models
{
    public class FinancialFlow : BaseEntity
    {
        public FinancialFlow(Guid idFamily,
                            DateTime dateMovement,
                            TypeMovementEnum typeMovement,
                            TypePaymentEnum typePayment,
                            string description,
                            string providerName,
                            Guid idMemberMovement,
                            string urlPaymentVoucher,
                            Double valueMovement,
                            SituationMovementEnum situationMovement,
                            string userCreate)
            : base(userCreate)
        {
            this.IdFamily = idFamily;
            this.IdMemberMovement = idMemberMovement;

            Movement = new Movement(dateMovement,
                                    description,
                                    providerName,
                                    typeMovement,
                                    typePayment,
                                    valueMovement,
                                    urlPaymentVoucher);
        }
        public Guid IdFamily { get; private set; }
        public Guid IdMemberMovement { get; private set; }
        public Movement Movement { get; private set; }
    }
}