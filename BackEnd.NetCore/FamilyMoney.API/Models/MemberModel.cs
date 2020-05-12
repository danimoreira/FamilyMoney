using System;
using System.ComponentModel.DataAnnotations;

namespace FamilyMoney.API.Models
{
    public class MemberModel
    {
        [Required]
        public Guid IdFamily { get; }
        [Required]
        [StringLength(60, ErrorMessage = "O Nome do Membro da Família não pode conter mais que 60 caracteres")]
        public string Name { get; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage="E-mail inválido.")]
        public string User { get; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; }
        [Required]
        [Compare("Password", ErrorMessage="As senhas não coincidem.")]
        public string ConfirmPassword { get; set; }
    }
}