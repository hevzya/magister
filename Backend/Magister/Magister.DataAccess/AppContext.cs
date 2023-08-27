using Magister.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Magister.DataAccess
{
    // Represents Database
    public class MagisterContext : IdentityDbContext<User>
    {
        public DbSet<Subject> Subjects { get; set; }

        public MagisterContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=Qwe123!!");
        }
    }
}
