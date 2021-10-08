namespace SmartAdmin.WebUI.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SmartAdmin.WebUI.Data.Models;

    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserFilterParameter> UserFilterParameters { get; set; }
        public DbSet<TagUserFilterParameter> TagUserFilterParameters { get; set; }
        public DbSet<GroupUserFilterParameter> GroupUserFilterParameters { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ProposedEventDate> ProposedEventDates { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<UserInGroup> UserInGroup { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}