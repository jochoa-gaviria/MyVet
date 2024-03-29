﻿using Microsoft.AspNetCore.Mvc.Rendering;
using MyVet.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Models
{
    public class HistoryViewModel : History
    {
        public int PetId { get; set; }

        [Display(Name="Service Type")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Service Type")]
        public int ServiceTypeId { get; set; }
        public IEnumerable<SelectListItem> ServiceTypes { get; set; }

    }
}
