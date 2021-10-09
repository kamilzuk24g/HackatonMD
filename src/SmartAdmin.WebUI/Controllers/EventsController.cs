using Microsoft.AspNetCore.Mvc;
using SmartAdmin.WebUI.Models;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using SmartAdmin.WebUI.Data;

    public class EventsController : Controller
    {
        //private readonly IDBService _iDBService;
        //private readonly IConfiguration Configuration;

        //public EventsController(IDBService context, IConfiguration configuration)
        //{
        //    _iDBService = context;
        //    Configuration = configuration;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        private ApplicationDbContext applicationDbContext;

        public EventsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult EventsList(EventsListFilterModel filters)
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
            int Paging = 100;
            //int.TryParse(Configuration["Paging"], out Paging);

            //return View(await _iDBService.EventsGet(
            //    filters.sortColumn, filters.filtrStatus,
            //    filters.filtrDataOd, filters.filtrDataDo,
            //    filters.pageIndex, Paging
            //    ));

            return View();
        }

        // GET: NumeryController
        public async Task<ActionResult> Index(EventsListFilterModel filters)
        {
            if (filters == null)
                filters = new EventsListFilterModel();

            ViewData.Add("filters", filters);
            int Paging = 100;
            //int.TryParse(Configuration["Paging"], out Paging);

            //return View(await _iDBService.EventsGet(
            //    filters.sortColumn, filters.filtrStatus,
            //    filters.filtrDataOd, filters.filtrDataDo,
            //    filters.pageIndex, Paging
            //    ));

            return View();
        }
    }
}