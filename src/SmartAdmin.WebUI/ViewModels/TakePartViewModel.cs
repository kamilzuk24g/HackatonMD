using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.ViewModels
{
    public class TakePartViewModel
    {
        public int EventId { get; set; }

        public List<DateTime> Dates { get; set; }

        public List<Selection> SelectedDates { get; set; }
    }

    public class Selection
    {
        public DateTime Date { get; set; }
        public bool Selected { get; set; }
    }
}