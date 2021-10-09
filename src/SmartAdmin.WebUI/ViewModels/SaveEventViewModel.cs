using System.Collections.Generic;

namespace SmartAdmin.WebUI.ViewModels
{
    public class SaveEventViewModel
    {
        public string EventName { get; set; }
        public string EventPlace { get; set; }
        public string EventDescription { get; set; }
        public EventDate[] EventDates { get; set; }
        public List<string> ProposedParticipants { get; set; }
        public List<string> ConfirmedParticipants { get; set; }
        public string EstimatedCost { get; set; }
        public List<string> Tags { get; set; }
    }

    public class EventDate
    {
        public string EventDateString { get; set; }

        public string EventTimeString { get; set; }
    }
}