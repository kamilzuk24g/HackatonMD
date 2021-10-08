using System;

namespace SmartAdmin.WebUI.ViewModels
{
    public class MyParametersViewModel
    {
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? PeopleMin { get; set; }
        public int? PeopleMax { get; set; }
        public bool? Success { get; set; }
    }
}