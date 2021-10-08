namespace SmartAdmin.WebUI.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SmartAdmin.WebUI.Data.Models;

    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Group> Groups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
