using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheSandwichShop.Models
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required]
        //[Compare("Password")]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }

    }
}
