using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreMvc.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Articles> Articles { get; set; }
        public DbSet<Chapters> Chapters { get; set; }
        public DbSet<Sections> Sections { get; set; }
    }
}
