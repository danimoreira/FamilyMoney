using System;
using System.ComponentModel.DataAnnotations;

namespace FamilyMoney.API.Models
{
    public class SavingsAccountModel
    {
        public int Id { get; set; }
        [Required]
        public int IdFamily { set; get; }
        [Required]
        public DateTime DateMovement { set; get; }
        [Required]
        public int TypeMovement { set; get; }
        [Required]
        public int TypePayment { set; get; }
        public string Description { set; get; }
        public string ProviderName { set; get; }
        [Required]
        public Guid IdMemberMovement { set; get; }
        public string UrlPaymentVoucher { set; get; }
        [Required]
        public Double ValueMovement { set; get; }
        [Required]
        public int SituationMovement { set; get; }
    }
}