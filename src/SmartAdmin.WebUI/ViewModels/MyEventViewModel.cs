using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.ViewModels
{
    public class GroupedMyEventsViewModel
    {
        public string Date { get; set; }

        public List<MyEventViewModel> DayEvents { get; set; }
    }

    public class MyEventViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public string Place { get; set; }

        public string IconPath { get; set; }

        public string Description { get; set; }

        public string MainPhotoPath { get; set; }
    }
}
