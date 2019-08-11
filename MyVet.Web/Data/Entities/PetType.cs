using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class PetType
    {
        public int Id { get; set; }

        [Display(Name = "Pet Type")]
        [MaxLength(20, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [Required(ErrorMessage ="The field {0} is mandatory")]
        public string Name { get; set; }
    }
}
