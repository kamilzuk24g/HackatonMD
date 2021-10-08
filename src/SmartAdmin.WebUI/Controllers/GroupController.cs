namespace SmartAdmin.WebUI.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SmartAdmin.WebUI.Data;
    using SmartAdmin.WebUI.Data.Models;
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

        public IActionResult JoinGroup(int groupId)
        {
            this.applicationDbContext.UserInGroup.Add(new UserInGroup()
            {
                GroupId = groupId,
                UserName = User.Identity.Name
            });

            this.applicationDbContext.SaveChanges();

            return RedirectToAction("Details", new { id = groupId });
        }

        public IActionResult LeaveGroup(int groupId)
        {
            var tmp = this.applicationDbContext.UserInGroup.FirstOrDefault(x => x.GroupId == groupId &&
            x.UserName == User.Identity.Name);

            this.applicationDbContext.UserInGroup.Remove(tmp);

            this.applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var viewModel = new GroupDetailsViewModel()
            {
                Group = this.applicationDbContext.Groups.FirstOrDefault(x => x.Id == id),
                Tags = this.applicationDbContext.Tags.Where(x => x.GroupId == id).ToList(),
                UserIsInGroup = this.applicationDbContext.UserInGroup.Any(x => x.GroupId == id && x.UserName == User.Identity.Name)
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GroupCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var group = new Group()
            {
                Name = viewModel.Name,
                Description = viewModel.Description
            };

            this.applicationDbContext.Groups.Add(group);

            this.applicationDbContext.SaveChanges();

            if (!string.IsNullOrEmpty(viewModel.Tags))
            {
                var tags = viewModel.Tags.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (tags.Length > 0)
                {
                    this.applicationDbContext.AddRange(tags.Select(x => new Tag()
                    {
                        GroupId = group.Id,
                        Name = x.Trim()
                    }));

                    this.applicationDbContext.SaveChanges();
                }
            }

            return RedirectToAction("Details", new { id = group.Id });
        }
    }
}