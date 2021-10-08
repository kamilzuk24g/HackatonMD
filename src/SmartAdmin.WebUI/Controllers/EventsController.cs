using Microsoft.AspNetCore.Mvc;
using SmartAdmin.WebUI.Models;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Controllers
{
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

        public IActionResult EventsList() => View();

        // GET: NumeryController
        public async Task<ActionResult> Index(EventsListFilterModel filters)
        {
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
