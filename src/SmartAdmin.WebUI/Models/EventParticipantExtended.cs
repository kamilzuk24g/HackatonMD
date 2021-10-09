using SmartAdmin.WebUI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Models
{
    public class EventParticipantExtended : EventParticipant
    {
        public List<DateTime> SelectedDates { get; set; }
    }
}