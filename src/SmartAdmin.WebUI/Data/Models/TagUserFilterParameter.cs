using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Data.Models
{
    public class TagUserFilterParameter
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int UserFilterParameterId { get; set; }
    }
}