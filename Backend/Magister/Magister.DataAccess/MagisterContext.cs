using Magister.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Magister.DataAccess
{
    // Represents Database
    public class MagisterContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentHomework> StudentHomeworks { get; set; }


        public MagisterContext(DbContextOptions<MagisterContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
