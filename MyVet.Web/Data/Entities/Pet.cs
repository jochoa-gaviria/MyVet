﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class Pet
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string Name { get; set; }

        [Display(Name="Image")]
        public string ImageUrl { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Race { get; set; }

        public Owner Owner { get; set; }

        public PetType PetType { get; set; }
        public ICollection<History> Histories { get; set; }
        public ICollection<Agenda> Agendas { get; set; }


        [Display(Name="Born Date")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Born { get; set; }

        public string Remarks { get; set; }

        //TODO: replace the correct URL for the image
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? "https://myvetjochoa.azurewebsites.net/images/Pets/noimage.png"
            : $"https://myvetjochoa.azurewebsites.net{ImageUrl.Substring(1)}";

        [Display(Name = "Born")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime BornLocal => Born.ToLocalTime();
    }

}
