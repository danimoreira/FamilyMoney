using System;
using FamilyMoney.Domain.Enums;
using FamilyMoney.Domain.ValueObjects;

namespace FamilyMoney.Domain.Entities
{
    public class SavingsAccount : BaseEntity
    {
        public SavingsAccount(Guid idFamily,
                            DateTime dateMovement,
                            TypeMovementEnum typeMovement,
                            TypePaymentEnum typePayment,
                            string description,
                            string providerName,
                            Guid idMemberMovement,
                            string urlPaymentVoucher,
                            Double valueMovement,
                            SituationMovementEnum situationMovement,
                            string userCreate,
                            string userUpdate)
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
        public Movement Movement {get; private set;}
    }
}