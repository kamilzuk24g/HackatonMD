using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Data.Models
{
    public class GroupUserFilterParameter
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int UserFilterParameterId { get; set; }
    }
}