using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartAdmin.WebUI.ViewModels;
using SmartAdmin.WebUI.Data;
using SmartAdmin.WebUI.Models;

namespace SmartAdmin.WebUI.Controllers
{
    public class EventovoController : Controller
    {
        private ApplicationDbContext applicationDbContext;

        public EventovoController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult MyEvents()
        {
            var model = new List<MyEventViewModel>()
            {
                new MyEventViewModel()
                {
                    Id = 1,
                     Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                                Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                      StartDate = new DateTime(2021,08,04),
                      Place = "Plac Uni lubelskiej",
                      IconPath = @"/img/demo/rails.png",
                      Title = "Moje pierwsze wydarzenie!"
                },
                new MyEventViewModel()
                {
                    Id = 2,
                     Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                                Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                      StartDate = new DateTime(2021,09,04),
                      Place = "Orlik @Stegny",
                      IconPath = @"/img/demo/react.png",
                      Title = "Moje drugie wydarzenie!"
                },
                new MyEventViewModel()
                {
                    Id = 3,
                     Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                                Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                      StartDate = new DateTime(2021,10,04),
                      Place = "MiNi PW",
                      IconPath = @"/img/demo/mvc.png",
                      Title = "Moje trzecie wydarzenie!",
                      MainPhotoPath = @"/img/demo/mvc.png",
                },
            };

            return View(model);
        }

        public IActionResult AddEvent() => View();

        public IActionResult Details(int id)
        {
            var eventDetails = this.applicationDbContext.Events.FirstOrDefault(x => x.Id == id);

            var eventDates = this.applicationDbContext.ProposedEventDates.Where(x => x.EventId == id)
                .Select(x => new ProposedEventDatesWithSummary()
                {
                    Date = x.ProposedDate
                }).ToList();

            var eventParticipantsTmp = this.applicationDbContext.EventParticipants.Where(x => x.EventId == id).ToList();
            var eventParticipants = new List<EventParticipantExtended>();
            foreach (var item in eventParticipantsTmp)
            {
                var dates = this.applicationDbContext.EventParticipantSelectedProposedDate
                    .Where(x => x.EventParticipantId == item.Id)
                    .Select(x => x.Date).ToList();

                eventParticipants.Add(new EventParticipantExtended()
                {
                    Id = item.Id,
                    EventId = item.EventId,
                    IsProposed = item.IsProposed,
                    Name = item.Name,
                    SelectedDates = dates
                });

                foreach (var date in eventDates)
                {
                    foreach (var selectedDate in dates)
                    {
                        if (date.Date == selectedDate)
                        {
                            date.Count++;
                        }
                    }
                }
            }

            var viewModel = new EventDetailsViewModel()
            {
                Id = id,
                Description = eventDetails.EventDescription,
                FinalEventDate = eventDetails.FinalEventDate,
                Place = eventDetails.EventPlace,
                IconPath = @"/img/demo/rails.png",
                Title = eventDetails.EventName,
                EstimatedCostPerPerson = eventDetails.EstimatedCostPerPerson.HasValue ? eventDetails.EstimatedCostPerPerson.Value.ToString("N2") + "PLN" : "",
                ProposedEventDates = eventDates,
                EventParticipants = eventParticipants,
                UserTakesPartInEvent = eventParticipants.Any(x => x.Name == User.Identity.Name)
            };

            return View(viewModel);
        }

        public IActionResult Leave(int id)
        {
            var eventParticipant = this.applicationDbContext.EventParticipants.FirstOrDefault(x => x.EventId == id && x.Name == User.Identity.Name);
            var selectedDates = this.applicationDbContext.EventParticipantSelectedProposedDate.Where(x => x.EventParticipantId == eventParticipant.Id).ToList();
            this.applicationDbContext.RemoveRange(selectedDates);
            this.applicationDbContext.Remove(eventParticipant);
            this.applicationDbContext.SaveChanges();

            return RedirectToAction("Details", new { id = id });
        }
    }
}