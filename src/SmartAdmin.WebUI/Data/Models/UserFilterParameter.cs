namespace SmartAdmin.WebUI.Data.Models
{
    using System;
    using System.Collections.Generic;
    using SmartAdmin.WebUI.Data.Migrations;

    public class UserFilterParameter
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? PeopleMin { get; set; }
        public int? PeopleMax { get; set; }
        public decimal? DurationFrom { get; set; }
        public decimal? DurationTo { get; set; }
    }
}