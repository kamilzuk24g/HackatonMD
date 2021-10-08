namespace SmartAdmin.WebUI.Data.Models
{
    public class EventParticipant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }
        public bool IsProposed { get; set; }
    }
}