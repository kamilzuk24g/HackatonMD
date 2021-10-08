namespace SmartAdmin.WebUI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SmartAdmin.WebUI.Data;
    using SmartAdmin.WebUI.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GroupController : Controller
    {
        private ApplicationDbContext applicationDbContext;

        public GroupController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var viewModel = new GroupsListViewModel()
            {
                Groups = this.applicationDbContext.Groups.ToList()
            };

            return View(viewModel);
        }
    }
}