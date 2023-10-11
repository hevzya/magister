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
        private readonly MagisterContext _context;

        public DatabaseInitializer(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            MagisterContext context)
        {

            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedData()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();

            #region Users and Roles

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
            }, "Qwe123!!");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "Mykola",
                Email = "mykola@gmail.com",
            }, "Qwe123!!");

            // Generate 100 Bigdans
            for (int i = 1; i < 100; i++)
            {
                await _userManager.CreateAsync(new User
                {
                    Id = Guid.NewGuid(),
                    UserName = $"Bogdan{i}",
                    Email = $"bogdan{i}@gmail.com",
                }, "Qwe123!!");

                var bigDen = await _userManager.FindByEmailAsync($"bogdan{i}@gmail.com");
                await _userManager.AddToRoleAsync(bigDen, "student");
            }

            await _userManager.CreateAsync(new User
            {
                UserName = "Admin",
                Email = "admin@gmail.com"
            }, "Qwe123!!");


            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "GalynaIvanivna",
                Email = "galyna1956@gmail.com",
            }, "Qwe123!!");

            var admin = await _userManager.FindByEmailAsync("admin@gmail.com");
            await _userManager.AddToRoleAsync(admin, "admin");

            var vasyan = await _userManager.FindByEmailAsync("vasyan@gmail.com");
            await _userManager.AddToRoleAsync(vasyan, "student");

            var mykola = await _userManager.FindByEmailAsync("mykola@gmail.com");
            await _userManager.AddToRoleAsync(mykola, "student");

            var galya = await _userManager.FindByEmailAsync("galyna1956@gmail.com");
            await _userManager.AddToRoleAsync(galya, "teacher");

            #endregion

            #region Subject

            var subjects = new List<Subject>()
            {
                new Subject 
                {
                    Name = "Math",
                    Description = "Math",
                    PlannedHours = 144,
                },
                new Subject
                {
                    Name = "Physics",
                    Description = "Physics",
                    PlannedHours = 128,
                },
            };

            await _context.Subjects.AddRangeAsync(subjects);
            await _context.SaveChangesAsync();

            #endregion

            #region Groups

            var groups = new List<Group>()
            {
                new Group
                {
                    GroupName = "1-A",
                },
                new Group
                {
                    GroupName = "1-B",
                }
            };

            await _context.Groups.AddRangeAsync(groups);
            await _context.SaveChangesAsync();

            #endregion

            #region Students

            var students = new List<Student>()
            {
                new Student
                {
                    Address = "Rivne, Soborna 69",
                    DateOfBirth = new DateTime(1997,2,7).ToUniversalTime(),
                    Name = "Vasyan",
                    Surname = "Vasyanov",
                    PhoneNumber = "1234567890",
                    User = await _userManager.FindByEmailAsync("vasyan@gmail.com"),
                    Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-A")
                },
                new Student
                {
                    Address = "Rivne, Soborna 322",
                    DateOfBirth = new DateTime(1996,4,22).ToUniversalTime(),
                    Name = "Mykola",
                    Surname = "Mykoliyk",
                    PhoneNumber = "1234567890",
                    User = await _userManager.FindByEmailAsync("mykola@gmail.com"),
                    Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-B")
                }
            };

            for (int i = 1; i < 100; i++)
            {
                students.Add(new Student
                {
                    Address = "Rivne, Soborna 322",
                    DateOfBirth = new DateTime(1997, 8, 22).ToUniversalTime(),
                    Name = $"Bogdan {i}",
                    Surname = "Budanov",
                    PhoneNumber = "1234567890",
                    User = await _userManager.FindByEmailAsync($"bogdan{i}@gmail.com"),
                    Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == (i < 50 ? "1-B" : "1-A"))
                });
            }

            await _context.Students.AddRangeAsync(students);
            await _context.SaveChangesAsync();

            #endregion

            #region Teachers

            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    Address = "Rivne, Chornovola 23",
                    DateOfBirth = new DateTime(1956, 2, 7).ToUniversalTime(),
                    Name = "Galyna Ivanivna",
                    Surname = "Ivaniuk",
                    PhoneNumber = "1234567890",
                    User = await _userManager.FindByEmailAsync("galyna1956@gmail.com"),
                }
            };

            await _context.Teachers.AddRangeAsync(teachers);
            await _context.SaveChangesAsync();

            #endregion







        }

    }
}
