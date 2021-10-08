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
    using SmartAdmin.WebUI.ViewModels;

    public class MyParametersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post(MyParametersViewModel viewModel)
        {
            return View("/Views/MyParameters/index.cshtml", viewModel);
        }
    }
}