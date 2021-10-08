using SmartAdmin.WebUI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.ViewModels
{
    public class GroupDetailsViewModel
    {
        public Group Group { get; set; }

        public List<Tag> Tags { get; set; }

        public bool UserIsInGroup { get; set; }
    }
}