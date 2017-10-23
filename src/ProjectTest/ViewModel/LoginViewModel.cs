using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="user name")]
        public string userName  { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public string returnUrl { get; set; }
    }
}
