using System;
using System.ComponentModel.DataAnnotations;

namespace FamilyMoney.API.Models
{
    public class MemberModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="O membro deve ser associado a uma família.")]
        public int IdFamily { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "O Nome do Membro da Família não pode conter mais que 60 caracteres")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inválido.")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage="O campo Role deve ser informado.")]
        public string Role { get; set; }

    }
}