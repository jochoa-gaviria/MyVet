using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        [Display(Name = "Document")]
        [MaxLength(20, ErrorMessage ="The field {0} cannot have more than {1} characters.")]
        [Required(ErrorMessage ="The field {0} is mandatory")]
        public string Document { get; set; }

        [Display(Name ="First Name")]
        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string LastName { get; set; }


        [Display(Name = "Fixed Phone")]
        [MaxLength(20, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string FixedPhone { get; set; }


        [Display(Name = "Cell Phone")]
        [MaxLength(20, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string CellPhone { get; set; }

        [MaxLength(100, ErrorMessage ="The field {0} cannot have more than {1} characters")]
        public string Address{ get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public string FullNameWithDocument => $"{FirstName}{LastName}-{Document}";
    }

}
