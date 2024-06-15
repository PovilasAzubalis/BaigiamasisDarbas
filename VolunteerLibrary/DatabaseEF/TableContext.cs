using Microsoft.EntityFrameworkCore;
using VolunteerManagmentLibrary.Models;
namespace VolunteerManagmentLibrary.DatabaseEF
{
    public class TableContext : DbContext
    {
        public TableContext(DbContextOptions options) : base(options) { }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Details>().HasNoKey();
        }

    }
}
