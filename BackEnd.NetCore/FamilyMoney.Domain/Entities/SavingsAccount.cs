using System;
using FamilyMoney.Domain.Enums;
using FamilyMoney.Domain.ValueObjects;

namespace FamilyMoney.Domain.Entities
{
    public class SavingsAccount : BaseEntity
    {
        protected SavingsAccount() {}

        public SavingsAccount(int idFamily,
                            DateTime dateMovement,
                            TypeMovementEnum typeMovement,
                            TypePaymentEnum typePayment,
                            string description,
                            string providerName,
                            int idMemberMovement,
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

        public int IdFamily { get; private set; }        
        public int IdMemberMovement { get; private set; }        
        public Movement Movement {get; private set;}

        public void Update(int idFamily,
                            DateTime dateMovement,
                            TypeMovementEnum typeMovement,
                            TypePaymentEnum typePayment,
                            string description,
                            string providerName,
                            int idMemberMovement,
                            string urlPaymentVoucher,
                            Double valueMovement,
                            SituationMovementEnum situationMovement,
                            string userUpdate)
        {
            this.IdFamily = idFamily;
            this.IdMemberMovement = idMemberMovement;

            Movement.Update(dateMovement, 
                            description,
                            providerName,
                            typeMovement,
                            typePayment,
                            valueMovement,
                            urlPaymentVoucher);

            base.Update(userUpdate);
        }
    }
}