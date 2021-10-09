using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartAdmin.WebUI.Models;
using System.Threading.Tasks;
using SmartAdmin.WebUI.ViewModels;

namespace SmartAdmin.WebUI.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using SmartAdmin.WebUI.Data;
    using SmartAdmin.WebUI.Data.Models;

    public class EventsController : Controller
    {
        private ApplicationDbContext applicationDbContext;

        public EventsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IActionResult> EventsList(EventsListFilterModel filters)
        {
            if (filters == null)
            {
                var filterParams = this.applicationDbContext.UserFilterParameters.FirstOrDefault(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
                filters = new EventsListFilterModel
                {
                    filterDateFrom = filterParams.DateFrom,
                    filterDateTo = filterParams.DateTo,
                    filterPriceFrom = filterParams.PriceMin,
                    filterPriceTo = filterParams.PriceMax,
                    // filterTimeFrom = filterParams.DurationFrom,
                    // filterTimeTo = filterParams.DurationTo,
                    // filterPeople = filterParams.PeopleMin,
                    // filterPeople = filterParams.PeopleMax,
                };
            }

            ViewData.Add("filters", filters);
            int pageSize = 100;

            if (filters.pageIndex == null || filters.pageIndex < 1)
                filters.pageIndex = 1;

            var query = applicationDbContext.Events.AsQueryable();

            if (filters.filterDateFrom.HasValue)
                query = query.Where(o => o.FinalEventDate >= filters.filterDateFrom.Value);
            if (filters.filterDateTo.HasValue)
                query = query.Where(o => o.FinalEventDate < filters.filterDateTo.Value.AddDays(1));

            if (string.IsNullOrEmpty(filters.filterTitle) == false)
                query = query.Where(o => o.EventName.ToLower().Contains(filters.filterTitle.ToLower()));
            if (string.IsNullOrEmpty(filters.filterDesc) == false)
                query = query.Where(o => o.EventDescription.ToLower().Contains(filters.filterDesc.ToLower()));
            if (string.IsNullOrEmpty(filters.filterPlace) == false)
                query = query.Where(o => o.EventPlace.ToLower().Contains(filters.filterPlace.ToLower()));

            if (filters.filterPriceFrom > 0)
                query = query.Where(o => o.EstimatedCostPerPerson >= filters.filterPriceFrom);
            if (filters.filterPriceTo > 0)
                query = query.Where(o => o.EstimatedCostPerPerson <= filters.filterPriceTo);

            if (filters.filterPeopleFrom > 0)
                query = query.Where(o => o.PeopleCount >= filters.filterPeopleFrom);
            if (filters.filterPeopleTo > 0)
                query = query.Where(o => o.PeopleCount <= filters.filterPeopleTo);

            if (filters.filterTimeFrom > 0)
                query = query.Where(o => o.Duration >= filters.filterTimeFrom);
            if (filters.filterTimeTo > 0)
                query = query.Where(o => o.Duration <= filters.filterTimeTo);

            switch (filters.sortColumn)
            {
                case "Id":
                    query = query.OrderBy(s => s.Id);
                    break;
                case "Id_d":
                    query = query.OrderByDescending(s => s.Id);
                    break;
                case "Data":
                    query = query.OrderBy(s => s.FinalEventDate);
                    break;
                case "Data_d":
                    query = query.OrderByDescending(s => s.FinalEventDate);
                    break;
                case "Title":
                    query = query.OrderBy(s => s.EventName);
                    break;
                case "Title_d":
                    query = query.OrderByDescending(s => s.EventName);
                    break;
                case "Description":
                    query = query.OrderBy(s => s.EventDescription);
                    break;
                case "Description_d":
                    query = query.OrderByDescending(s => s.EventDescription);
                    break;
                case "Place":
                    query = query.OrderBy(s => s.EventPlace);
                    break;
                case "Place_d":
                    query = query.OrderByDescending(s => s.EventPlace);
                    break;
                case "Price":
                    query = query.OrderBy(s => s.EstimatedCostPerPerson);
                    break;
                case "Price_d":
                    query = query.OrderByDescending(s => s.EstimatedCostPerPerson);
                    break;
                case "Time_":
                    query = query.OrderBy(s => s.Duration);
                    break;
                case "Time_d":
                    query = query.OrderByDescending(s => s.Duration);
                    break;
                case "People":
                    query = query.OrderBy(s => s.PeopleCount);
                    break;
                case "People_d":
                    query = query.OrderByDescending(s => s.PeopleCount);
                    break;
                case "Tags":
                    query = query.OrderByDescending(s => s.TagsCount);
                    break;
                case "Tags_d":
                    query = query.OrderByDescending(s => s.TagsCount);
                    break;
                default:
                    query = query.OrderByDescending(s => s.Id);
                    break;
            }

            var list = await PagingList<Event>.CreateAsync(query, filters.pageIndex, pageSize);


            return View(list);
        }

        public async Task<IActionResult> AddEvent()
        {
            return View("~/Views/Eventovo/addevent.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> SaveEvent([FromBody] SaveEventViewModel eventData)
        {
            decimal? parsedEstimatedCostNullable = null;
            if (decimal.TryParse(eventData.EstimatedCost, out decimal parsedEstimatedCost))
            {
                parsedEstimatedCostNullable = parsedEstimatedCost;
            }
            
            var databaseModel = new Event
            {
                EventName = eventData.EventName,
                EstimatedCostPerPerson = parsedEstimatedCost,
                EventDescription = eventData.EventDescription,
                EventPlace = eventData.EventPlace,
                EventParticipants = eventData.ProposedParticipants.Select(pp => new EventParticipant
                {
                    Name = pp,
                    IsProposed = true
                }).Concat(eventData.ConfirmedParticipants.Select(cp => new EventParticipant { Name = cp}).ToList()).ToList()
            };
            
            return Ok();
        }
    }
}