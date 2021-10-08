using System;

namespace SmartAdmin.WebUI.Data.Models
{
    public class ProposedEventDate
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public DateTime ProposedDate { get; set; }
    }
}