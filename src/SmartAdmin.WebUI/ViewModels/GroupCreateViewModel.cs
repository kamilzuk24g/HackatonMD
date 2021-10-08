using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.ViewModels
{
    public class GroupCreateViewModel
    {
        [Required(ErrorMessage = "Pole nazwa jest wymagane")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole opis jest wymagane")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Pole #Hasztagi jest wymagane")]
        public string Tags { get; set; }
    }
}