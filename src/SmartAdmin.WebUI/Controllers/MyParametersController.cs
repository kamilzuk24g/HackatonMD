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
    using System;
    using System.Linq;
    using System.Security.Claims;
    using SmartAdmin.WebUI.Data;
    using SmartAdmin.WebUI.Data.Models;
    using SmartAdmin.WebUI.ViewModels;

    public class MyParametersController : Controller
    {
        private ApplicationDbContext applicationDbContext;

        public MyParametersController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var filterParams = this.applicationDbContext.UserFilterParameters.FirstOrDefault(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (filterParams != null)
            {
                return this.View(new MyParametersViewModel
                {
                    DateFrom = filterParams.DateFrom,
                    DateTo = filterParams.DateTo,
                    PeopleMax = filterParams.PeopleMax,
                    PeopleMin = filterParams.PeopleMin,
                    PriceMax = filterParams.PriceMax,
                    PriceMin = filterParams.PriceMin
                });
            }

            return View();
        }

        public IActionResult Post(MyParametersViewModel viewModel)
        {
            try
            {
                var filterParams = this.applicationDbContext.UserFilterParameters.FirstOrDefault(x =>
                    x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (filterParams != null)
                {
                    filterParams.DateFrom = viewModel.DateFrom;
                    filterParams.DateTo = viewModel.DateTo;
                    filterParams.PriceMax = viewModel.PriceMax;
                    filterParams.PriceMin = viewModel.PriceMin;
                    filterParams.PeopleMax = viewModel.PeopleMax;
                    filterParams.PeopleMin = viewModel.PeopleMin;
                }
                else
                {
                    this.applicationDbContext.UserFilterParameters.Add(
                        new UserFilterParameter
                        {
                            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                            DateFrom = viewModel.DateFrom,
                            DateTo = viewModel.DateTo,
                            PriceMax = viewModel.PriceMax,
                            PriceMin = viewModel.PriceMin,
                            PeopleMax = viewModel.PeopleMax,
                            PeopleMin = viewModel.PeopleMin
                        });
                }

                this.applicationDbContext.SaveChanges();
                viewModel.Success = true;
            }
            catch (Exception ex)
            {
                viewModel.Success = false;
            }

            return View("/Views/MyParameters/index.cshtml", viewModel);
        }
    }
}