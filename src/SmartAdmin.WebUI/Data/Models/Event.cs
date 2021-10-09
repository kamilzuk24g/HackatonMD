using System;
using System.Collections;
using System.Collections.Generic;

namespace SmartAdmin.WebUI.Data.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventPlace { get; set; }
        public string EventDescription { get; set; }
        public List<ProposedEventDate> ProposedEventDates { get; set; }
        public DateTime? FinalEventDate { get; set; }
        public List<EventParticipant> EventParticipants { get; set; }
        public decimal? EstimatedCostPerPerson { get; set; }
        public List<Tag> Tags { get; set; }
        public decimal? Duration { get; set; }
        public int TagsCount { get; set; }
        public int PeopleCount { get; set; }
    }
}