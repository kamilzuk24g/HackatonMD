using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Data.Models
{
    public class EventParticipantSelectedProposedDate
    {
        public int Id { get; set; }

        public int EventParticipantId { get; set; }

        public DateTime Date { get; set; }
    }
}