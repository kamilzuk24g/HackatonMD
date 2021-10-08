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
    using SmartAdmin.WebUI.Data;

    public class MyParametersController : Controller
    {
        public IActionResult MyParameters()
        {
            return View();
        }
    }
}