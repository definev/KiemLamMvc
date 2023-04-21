using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreMvc.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<ChuongMuc> ChuongMuc { get; set; }
        public DbSet<DieuLuatChuongMuc> MovieGenre { get; set; }
        public DbSet<DieuLuat> Movie { get; set; }
    }
}
