using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.ViewModels
{
    public class EventDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? FinalEventDate { get; set; }

        public string Place { get; set; }

        public string IconPath { get; set; }

        public string Description { get; set; }

        public string MainPhotoPath { get; set; }

        public string EstimatedCostPerPerson { get; set; }

        public List<DateTime> ProposedEventDates { get; set; }
    }
}