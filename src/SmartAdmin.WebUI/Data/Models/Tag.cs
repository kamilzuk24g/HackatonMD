namespace SmartAdmin.WebUI.Data.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public int? GroupId { get; set; }

        public int? EventId { get; set; }

        public string Name { get; set; }
    }
}