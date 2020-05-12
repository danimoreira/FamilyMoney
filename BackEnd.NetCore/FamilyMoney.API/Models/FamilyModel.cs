using System;
using System.ComponentModel.DataAnnotations;

namespace FamilyMoney.API.Models
{
    public class FamilyModel
    {
        [Required]
        [StringLength(60, ErrorMessage="O nome não deve conter mais do que 60 caracteres.")]
        public string Name {set; get;}
    }
}