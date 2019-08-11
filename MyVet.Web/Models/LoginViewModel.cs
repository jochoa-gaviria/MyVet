using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyVet.Web.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Username or email")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [EmailAddress]
        public string Username { get; set; }
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MinLength(6,ErrorMessage = "The field {0} must have more than {1} characters")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
