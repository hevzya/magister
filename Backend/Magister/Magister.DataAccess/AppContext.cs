using Magister.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Magister.DataAccess
{
    // Represents Database
    public class MagisterContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Subject> Subjects { get; set; }

        public MagisterContext(DbContextOptions<MagisterContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
