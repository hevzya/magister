using Magister.DataAccess;
using Magister.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Magister.DbInitializer
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly DbContext _context;

        public DatabaseInitializer(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            DbContext context) {

            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedData()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();

            //Create roles
            await _roleManager.CreateAsync(new Role { Name = "admin" });
            await _roleManager.CreateAsync(new Role { Name = "teacher" });
            await _roleManager.CreateAsync(new Role { Name = "student" });

            //Create users
            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "Vasyan",
                Email = "vasyan@gmail.com",
                Address = "Рівне Чорновола 64",
                Age = 27,
                Gender = "Ч"
            }, "Qwe123!!");

            await _userManager.CreateAsync(new User
            {
                UserName = "Admin",
                Email = "admin@gmail.com"
            }, "Qwe123!!");

            var admin = await _userManager.FindByEmailAsync("admin@gmail.com");
            await _userManager.AddToRoleAsync(admin, "admin");

            var vasyan = await _userManager.FindByEmailAsync("vasyan@gmail.com");
            await _userManager.AddToRoleAsync(vasyan, "student");
        }

    }
}
