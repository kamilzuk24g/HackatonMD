using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Models
{
    public class EventsListFilterModel
    {
        public string sortColumn { get; set; }
        public int pageIndex { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? filterDateFrom { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? filterDateTo { get; set; }
        public string filterTitle { get; set; }
        public string filterDesc { get; set; }
        public string filterPlace { get; set; }
        public decimal? filterPriceFrom { get; set; }
        public decimal? filterPriceTo { get; set; }
        public decimal? filterTimeFrom { get; set; }
        public decimal? filterTimeTo { get; set; }
        public int? filterPeopleFrom { get; set; }
        public int? filterPeopleTo { get; set; }
        public string filterTags { get; set; }
        public string filterCustom { get; set; }

    }
}
