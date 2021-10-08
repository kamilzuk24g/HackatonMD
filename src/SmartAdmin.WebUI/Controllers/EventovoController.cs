using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Controllers
{
    public class EventovoController : Controller
    {
        public IActionResult MyEvents() => View();
        public IActionResult AddEvent() => View();
        public IActionResult MyParameters() => View();
    }
}