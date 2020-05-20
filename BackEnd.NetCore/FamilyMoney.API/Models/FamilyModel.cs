using System;
using System.ComponentModel.DataAnnotations;

namespace FamilyMoney.API.Models
{
    public class FamilyModel
    {
        public int Id {set; get;}
        
        [Required(ErrorMessage="O nome da familia é obrigatório",AllowEmptyStrings=false)]
        [StringLength(60, ErrorMessage="O nome não deve conter mais do que 60 caracteres.")]
        public string Name {set; get;}
    }
}