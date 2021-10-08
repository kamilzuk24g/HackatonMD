// //-----------------------------------------------------------------------
// // <copyright file="MyParametersController.cs.cs" company="Bank Millennium SA">
// //   Copyright © Bank Millennium SA 2017
// // </copyright>
// // <summary>
// //  The MyParametersController.cs class
// // </summary>
// //-----------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;

namespace SmartAdmin.WebUI.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using SmartAdmin.WebUI.Data;
    using SmartAdmin.WebUI.Data.Models;
    using SmartAdmin.WebUI.ViewModels;

    public class MyParametersController : Controller
    {
        private ApplicationDbContext applicationDbContext;
        private IdentityUser identityUser;
        private UserFilterParameter filterParams;

        public MyParametersController(ApplicationDbContext applicationDbContext, IdentityUser identityUser)
        {
            this.applicationDbContext = applicationDbContext;
            this.identityUser = identityUser;
        }

        public IActionResult Index()
        {
            this.filterParams = this.applicationDbContext.UserFilterParameters.FirstOrDefault(x => x.UserId == this.identityUser.Id);
            if (filterParams != null)
            {
                return this.View(new MyParametersViewModel
                {
                    DateFrom = filterParams.DateFrom,
                    DateTo = filterParams.DateTo,
                    PeopleMax = filterParams.PeopleMax,
                    PeopleMin = filterParams.PeopleMin,
                    PriceMax = filterParams.PriceMax,
                    PriceMin = filterParams.PriceMin,
                    Remote = filterParams.Remote
                });
            }

            return View();
        }

        public IActionResult Post(MyParametersViewModel viewModel)
        {
            if (this.filterParams != null)
            {
                this.filterParams.DateFrom = viewModel.DateFrom;
                this.filterParams.DateTo = viewModel.DateTo;
                this.filterParams.PriceMax = viewModel.PriceMax;
                this.filterParams.PriceMin = viewModel.PriceMin;
                this.filterParams.PeopleMax = viewModel.PeopleMax;
                this.filterParams.PeopleMin = viewModel.PeopleMin;
                this.filterParams.Remote = viewModel.Remote;
            }
            else
            {
                this.applicationDbContext.UserFilterParameters.Add(
                    new UserFilterParameter
                    {
                        DateFrom = viewModel.DateFrom,
                        DateTo = viewModel.DateTo,
                        PriceMax = viewModel.PriceMax,
                        PriceMin = viewModel.PriceMin,
                        PeopleMax = viewModel.PeopleMax,
                        PeopleMin = viewModel.PeopleMin,
                        Remote = viewModel.Remote
                    });
            }

            this.applicationDbContext.SaveChanges();

            return View("/Views/MyParameters/index.cshtml", viewModel);
        }
    }
}