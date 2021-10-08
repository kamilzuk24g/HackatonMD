using Microsoft.AspNetCore.Mvc;
using SmartAdmin.WebUI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Controllers
{
    public class TagsController : Controller
    {
        private ApplicationDbContext applicationDbContext;

        public TagsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult Delete(int id)
        {
            var tag = this.applicationDbContext.Tags.First(x => x.Id == id);

            this.applicationDbContext.Tags.Remove(tag);

            return RedirectToAction("Detail", "Group", new { id = tag.GroupId });
        }
    }
}