using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SmartAdmin.WebUI.Models
{
    using System.Security.Claims;

    public class ViewBagFilter : IActionFilter
    {
        private static readonly string Enabled = "Enabled";
        private static readonly string Disabled = string.Empty;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is Controller controller)
            {
                // SmartAdmin Toggle Features
                controller.ViewBag.AppSidebar = Enabled;
                controller.ViewBag.AppHeader = Enabled;
                controller.ViewBag.AppLayoutShortcut = Enabled;
                controller.ViewBag.AppFooter = Enabled;
                controller.ViewBag.ShortcutMenu = Enabled;
                controller.ViewBag.ChatInterface = Enabled;
                controller.ViewBag.LayoutSettings = Enabled;

                // SmartAdmin Default Settings
                controller.ViewBag.App = "Eventovo";
                controller.ViewBag.AppName = "Eventovo";
                controller.ViewBag.AppFlavor = "Eventovo";
                controller.ViewBag.AppFlavorSubscript = "";
                controller.ViewBag.User = controller.User.FindFirstValue(ClaimTypes.Name);
                controller.ViewBag.Email = "drlantern@gotbootstrap.com";
                controller.ViewBag.Twitter = "codexlantern";
                controller.ViewBag.Avatar = "avatar-admin.png";
                controller.ViewBag.Version = "4.0.2";
                controller.ViewBag.Bs4v = "4.3";
                controller.ViewBag.Logo = "logo.png";
                controller.ViewBag.LogoM = "logo.png";
                controller.ViewBag.Copyright = "2019 © Eventovo by&nbsp;<a href='https = //www.gotbootstrap.com' class='text-primary fw-500' title='gotbootstrap.com' target='_blank'>gotbootstrap.com</a>";
                controller.ViewBag.CopyrightInverse = "2019 © Eventovo by&nbsp;<a href='https = //www.gotbootstrap.com' class='text-white opacity-40 fw-500' title='gotbootstrap.com' target='_blank'>gotbootstrap.com</a>";
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}