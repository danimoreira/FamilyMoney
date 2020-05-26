using System;
using System.ComponentModel.DataAnnotations;
using FamilyMoney.Domain.Enums;

namespace FamilyMoney.API.Models
{
    public class FinancialFlowModel
    {        
        public int Id {set; get;}
        [Required]
        public int IdFamily { set; get; }
        [Required]
        public DateTime DateMovement { set; get; }
        [Required]
        public TypeMovementEnum TypeMovement { set; get; }
        [Required]
        public TypePaymentEnum TypePayment { set; get; }
        public string Description { set; get; }
        public string ProviderName { set; get; }
        [Required]
        public int IdMemberMovement { set; get; }
        public string UrlPaymentVoucher { set; get; }
        [Required]
        public Double ValueMovement { set; get; }
        [Required]
        public SituationMovementEnum SituationMovement { set; get; }
    }
}