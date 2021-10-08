namespace SmartAdmin.WebUI.ViewModels
{
    using SmartAdmin.WebUI.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GroupsListViewModel
    {
        [Required(ErrorMessage = "Pole wartość wyszykiwania jest wymagane")]
        public string SearchValue { get; set; }

        public List<Group> Groups { get; set; }

        public bool IsMy { get; set; }
    }
}