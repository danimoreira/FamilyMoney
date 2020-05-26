using System.ComponentModel.DataAnnotations;

namespace FamilyMoney.API.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inválido.")]
        public string User { get; set; }
        [Required]
        public string Password { get; set; }
    }
}