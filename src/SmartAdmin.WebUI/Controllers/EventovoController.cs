using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartAdmin.WebUI.ViewModels;

namespace SmartAdmin.WebUI.Controllers
{
    public class EventovoController : Controller
    {
        public IActionResult MyEvents()
        {
            var model = new List<MyEventViewModel>()
            {
                new MyEventViewModel()
                {
                     Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                                Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                      StartDate = new DateTime(2021,08,04),
                      EndDate = new DateTime(2021,08,04),
                      IconPath = @"/img/demo/rails.png",
                      Title = "Moje pierwsze wydarzenie!"
                },
                new MyEventViewModel()
                {
                     Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                                Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                      StartDate = new DateTime(2021,09,04),
                      EndDate = new DateTime(2021,09,04),
                      IconPath = @"/img/demo/react.png",
                      Title = "Moje drugie wydarzenie!"
                },
            };

            return View(model);
        }

        public IActionResult AddEvent() => View();
    }
}