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
                controller.ViewBag.ShortcutMenu = Disabled;
                controller.ViewBag.ChatInterface = Disabled;
                controller.ViewBag.LayoutSettings = Enabled;

                // SmartAdmin Default Settings
                controller.ViewBag.App = "Eventovo";
                controller.ViewBag.AppName = "Eventovo";
                controller.ViewBag.AppFlavor = "VENTOVO";
                controller.ViewBag.AppFlavorSubscript = "";
                controller.ViewBag.User = controller.User.FindFirstValue(ClaimTypes.Name);
                controller.ViewBag.Email = controller.User.FindFirstValue(ClaimTypes.Email);
                controller.ViewBag.Twitter = "codexlantern";
                controller.ViewBag.Avatar = "avatar-admin.png";
                controller.ViewBag.Version = "4.0.2";
                controller.ViewBag.Bs4v = "4.3";
                controller.ViewBag.Logo = "millelogo.png";
                controller.ViewBag.LogoM = "millelogo.png";
                controller.ViewBag.Copyright = "2021 © Eventovo by MD";
                controller.ViewBag.CopyrightInverse = "2021 © Eventovo by MD";
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}