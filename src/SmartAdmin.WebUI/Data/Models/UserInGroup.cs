using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Data.Models
{
    public class UserInGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string UserName { get; set; }
    }
}