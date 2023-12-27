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
                UserName = "Admin",
                Email = "admin@gmail.com"
            }, "Qwe123!!");

            var admin = await _userManager.FindByEmailAsync("admin@gmail.com");
            await _userManager.AddToRoleAsync(admin, "admin");

            //STUDENTS ACCOUNTS

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "alex123",
                Email = "alex@example.com",
                Gender = "Male"
            }, "Qwe123!!");

            var alex123 = await _userManager.FindByEmailAsync("alex@example.com");
            await _userManager.AddToRoleAsync(alex123, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "emily123",
                Email = "emily@example.com",
                Gender = "Female"
            }, "Qwe123!!");

            var emily123 = await _userManager.FindByEmailAsync("emily@example.com");
            await _userManager.AddToRoleAsync(emily123, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "james789",
                Email = "james@example.com",
            }, "Zxc789!!");

            var James789 = await _userManager.FindByEmailAsync("james@example.com");
            await _userManager.AddToRoleAsync(James789, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "sophia123",
                Email = "sophia@example.com",
            }, "Vbn123!!");

            var Sophia123 = await _userManager.FindByEmailAsync("sophia@example.com");
            await _userManager.AddToRoleAsync(Sophia123, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "william234",
                Email = "william@example.com",
            }, "Mnb234!!");

            var William234 = await _userManager.FindByEmailAsync("william@example.com");
            await _userManager.AddToRoleAsync(William234, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "emma567",
                Email = "emma@example.com",
            }, "Fgh567!!");

            var Emma567 = await _userManager.FindByEmailAsync("emma@example.com");
            await _userManager.AddToRoleAsync(Emma567, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "emma777",
                Email = "emma2@example.com",
            }, "Fgh567!!");

            var Emma777 = await _userManager.FindByEmailAsync("emma2@example.com");
            await _userManager.AddToRoleAsync(Emma777, "student");


            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "oliver456",
                Email = "oliver@example.com",
            }, "Oliver123!!");

            var Oliver456 = await _userManager.FindByEmailAsync("oliver@example.com");
            await _userManager.AddToRoleAsync(Oliver456, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "liam567",
                Email = "liam@example.com",
            }, "Liam123!!");

            var Liam567 = await _userManager.FindByEmailAsync("liam@example.com");
            await _userManager.AddToRoleAsync(Liam567, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "ava678",
                Email = "ava@example.com",
            }, "Ava123!!");

            var Ava678 = await _userManager.FindByEmailAsync("ava@example.com");
            await _userManager.AddToRoleAsync(Ava678, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "noah789",
                Email = "noah@example.com",
            }, "Noah123!!");

            var Noah789 = await _userManager.FindByEmailAsync("noah@example.com");
            await _userManager.AddToRoleAsync(Noah789, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "isabella890",
                Email = "isabella@example.com",
            }, "Isabella123!!");

            var Isabella890 = await _userManager.FindByEmailAsync("isabella@example.com");
            await _userManager.AddToRoleAsync(Isabella890, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "mia901",
                Email = "mia@example.com",
            }, "Mia123!!");

            var Mia901 = await _userManager.FindByEmailAsync("mia@example.com");
            await _userManager.AddToRoleAsync(Mia901, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "lucas012",
                Email = "lucas@example.com",
            }, "Lucas123!!");

            var Lucas012 = await _userManager.FindByEmailAsync("lucas@example.com");
            await _userManager.AddToRoleAsync(Lucas012, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "sophia345",
                Email = "sophia2@example.com",
            }, "Sophia123!!");

            var Sophia345 = await _userManager.FindByEmailAsync("sophia2@example.com");
            await _userManager.AddToRoleAsync(Sophia345, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "ethan567",
                Email = "ethan@example.com",
            }, "Ethan123!!");

            var Ethan567 = await _userManager.FindByEmailAsync("ethan@example.com");
            await _userManager.AddToRoleAsync(Ethan567, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "amelia678",
                Email = "amelia@example.com",
            }, "Amelia123!!");

            var Amelia678 = await _userManager.FindByEmailAsync("amelia@example.com");
            await _userManager.AddToRoleAsync(Amelia678, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "jackson789",
                Email = "jackson@example.com",
            }, "Jackson123!!");

            var Jackson789 = await _userManager.FindByEmailAsync("jackson@example.com");
            await _userManager.AddToRoleAsync(Jackson789, "student");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "charlotte890",
                Email = "charlotte@example.com",
            }, "Charlotte123!!");

            var Charlotte890 = await _userManager.FindByEmailAsync("charlotte@example.com");
            await _userManager.AddToRoleAsync(Charlotte890, "student");

            //TEACHERS ACCOUNTS
            //
            //
            //

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "john123",
                Email = "johnTeacher@example.com",
            }, "John123!!");

            var John123 = await _userManager.FindByEmailAsync("johnTeacher@example.com");
            await _userManager.AddToRoleAsync(John123, "teacher");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "emily234",
                Email = "emilyTeacher@example.com",
            }, "Emily123!!");

            var Emily234 = await _userManager.FindByEmailAsync("emilyTeacher@example.com");
            await _userManager.AddToRoleAsync(Emily234, "teacher");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "michael345",
                Email = "michaelTeacher@example.com",
            }, "Michael123!!");

            var Michael345 = await _userManager.FindByEmailAsync("michaelTeacher@example.com");
            await _userManager.AddToRoleAsync(Michael345, "teacher");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "emma456",
                Email = "emmaTeacher@example.com",
            }, "Emma123!!");

            var Emma456 = await _userManager.FindByEmailAsync("emmaTeacher@example.com");
            await _userManager.AddToRoleAsync(Emma456, "teacher");

            await _userManager.CreateAsync(new User
            {
                Id = Guid.NewGuid(),
                UserName = "daniel567",
                Email = "danielTeacher@example.com",
            }, "Daniel123!!");

            var Daniel567 = await _userManager.FindByEmailAsync("danielTeacher@example.com");
            await _userManager.AddToRoleAsync(Daniel567, "teacher");
            #endregion

            #region Subject

            var subjects = new List<Subject>()
            {
                new Subject
                {
                    Name = "Math",
                    Description = "Mathematics",
                    PlannedHours = 144,
                },
                new Subject
                {
                    Name = "Physics",
                    Description = "Physics",
                    PlannedHours = 128,
                },
                new Subject
                {
                    Name = "Biology",
                    Description = "Biology",
                    PlannedHours = 100,
                },
                new Subject
                {
                    Name = "Chemistry",
                    Description = "Chemistry",
                    PlannedHours = 120,
                },
                new Subject
                {
                    Name = "History",
                    Description = "History",
                    PlannedHours = 90,
                }
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
                },
                new Group
                {
                    GroupName = "2-A",
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
                            Address = "12 Main St",
                            DateOfBirth = new DateTime(2001, 3, 12).ToUniversalTime(),
                            Name = "Alex",
                            Surname = "Smith",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("alex@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-A")
                        },
                        new Student
                        {
                            Address = "34 Center St",
                            DateOfBirth = new DateTime(2000, 5, 8).ToUniversalTime(),
                            Name = "Emily",
                            Surname = "Johnson",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("emily@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-A")
                        },
                        new Student
                        {
                            Address = "56 North St",
                            DateOfBirth = new DateTime(2001, 1, 20).ToUniversalTime(),
                            Name = "James",
                            Surname = "Williams",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("james@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-A")
                        },
                        new Student
                        {
                            Address = "78 East St",
                            DateOfBirth = new DateTime(2000, 7, 5).ToUniversalTime(),
                            Name = "Sophia",
                            Surname = "Brown",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("sophia@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-A")
                        },
                        new Student
                        {
                            Address = "42 Oak St",
                            DateOfBirth = new DateTime(2000, 9, 12).ToUniversalTime(),
                            Name = "William",
                            Surname = "Davis",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("william@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-A")
                        },

                        new Student
                        {
                            Address = "56 Pine St",
                            DateOfBirth = new DateTime(2001, 2, 28).ToUniversalTime(),
                            Name = "Emma",
                            Surname = "Martinez",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("emma@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-A")
                        },
                        new Student
                        {
                            Address = "42 Main St",
                            DateOfBirth = new DateTime(2001, 5, 15).ToUniversalTime(),
                            Name = "Emma",
                            Surname = "Johnson",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("emma2@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-B")
                        },
                        new Student
                        {
                            Address = "15 Center St",
                            DateOfBirth = new DateTime(2000, 3, 25).ToUniversalTime(),
                            Name = "Oliver",
                            Surname = "Garcia",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("oliver@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-B")
                        },
                        new Student
                        {
                            Address = "87 North St",
                            DateOfBirth = new DateTime(2001, 8, 10).ToUniversalTime(),
                            Name = "Liam",
                            Surname = "Martinez",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("liam@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-B")
                        },
                        new Student
                        {
                            Address = "63 South St",
                            DateOfBirth = new DateTime(2000, 4, 20).ToUniversalTime(),
                            Name = "Ava",
                            Surname = "Miller",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("ava@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-B")
                        },
                        new Student
                        {
                            Address = "29 West St",
                            DateOfBirth = new DateTime(2001, 2, 5).ToUniversalTime(),
                            Name = "Noah",
                            Surname = "Smith",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("noah@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-B")
                        },
                        new Student
                        {
                            Address = "50 East St",
                            DateOfBirth = new DateTime(2000, 9, 18).ToUniversalTime(),
                            Name = "Isabella",
                            Surname = "Brown",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("isabella@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-B")
                        },
                        new Student
                        {
                            Address = "21 Main St",
                            DateOfBirth = new DateTime(2001, 7, 22).ToUniversalTime(),
                            Name = "Mia",
                            Surname = "Johnson",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("mia@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "2-A")
                        },
                        new Student
                        {
                            Address = "37 Center St",
                            DateOfBirth = new DateTime(2000, 6, 14).ToUniversalTime(),
                            Name = "Lucas",
                            Surname = "Garcia",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("lucas@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "2-A")
                        },
                        new Student
                        {
                            Address = "94 North St",
                            DateOfBirth = new DateTime(2001, 4, 9).ToUniversalTime(),
                            Name = "Sophia",
                            Surname = "Martinez",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("sophia2@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "2-A")
                        },
                        new Student
                        {
                            Address = "45 South St",
                            DateOfBirth = new DateTime(2000, 11, 30).ToUniversalTime(),
                            Name = "Ethan",
                            Surname = "Miller",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("ethan@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "2-A")
                        },
                        new Student
                        {
                            Address = "18 West St",
                            DateOfBirth = new DateTime(2001, 10, 25).ToUniversalTime(),
                            Name = "Amelia",
                            Surname = "Smith",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("amelia@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "2-A")
                        },
                        new Student
                        {
                            Address = "77 East St",
                            DateOfBirth = new DateTime(2000, 12, 18).ToUniversalTime(),
                            Name = "Jackson",
                            Surname = "Brown",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("jackson@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "2-A")
                        },
                        new Student
                        {
                            Address = "33 Main St",
                            DateOfBirth = new DateTime(2001, 11, 10).ToUniversalTime(),
                            Name = "Charlotte",
                            Surname = "Johnson",
                            PhoneNumber = "1234567890",
                            User = await _userManager.FindByEmailAsync("charlotte@example.com"),
                            Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "2-A")
                        }
            };




            await _context.Students.AddRangeAsync(students);
            await _context.SaveChangesAsync();

            #endregion

            #region Teachers

            var teachers = new List<Teacher>()
            {
                new Teacher
                {
                    Address = "Rivne, Chornovola 23",
                    DateOfBirth = new DateTime(1980, 2, 7).ToUniversalTime(),
                    Name = "John Smith",
                    Surname = "Johnson",
                    PhoneNumber = "1234567890",
                    User = await _userManager.FindByEmailAsync("johnTeacher@example.com"),
                },
                new Teacher
                {
                    Address = "Kyiv, Shevchenka 15",
                    DateOfBirth = new DateTime(1975, 4, 12).ToUniversalTime(),
                    Name = "Emily Davis",
                    Surname = "Miller",
                    PhoneNumber = "1234567890",
                    User = await _userManager.FindByEmailAsync("emilyTeacher@example.com"),
                },
                new Teacher
                {
                    Address = "Lviv, Bandery 5",
                    DateOfBirth = new DateTime(1978, 6, 20).ToUniversalTime(),
                    Name = "Michael Garcia",
                    Surname = "Brown",
                    PhoneNumber = "1234567890",
                    User = await _userManager.FindByEmailAsync("michaelTeacher@example.com"),
                },
                new Teacher
                {
                    Address = "Odessa, Deribasovska 10",
                    DateOfBirth = new DateTime(1982, 8, 25).ToUniversalTime(),
                    Name = "Emma Wilson",
                    Surname = "Smith",
                    PhoneNumber = "1234567890",
                    User = await _userManager.FindByEmailAsync("emmaTeacher@example.com"),
                },
                new Teacher
                {
                    Address = "Kharkiv, Lenina 7",
                    DateOfBirth = new DateTime(1979, 10, 5).ToUniversalTime(),
                    Name = "Daniel Martinez",
                    Surname = "Johnson",
                    PhoneNumber = "1234567890",
                    User = await _userManager.FindByEmailAsync("danielTeacher@example.com"),
                }
            };


            await _context.Teachers.AddRangeAsync(teachers);
            await _context.SaveChangesAsync();

            #endregion

            #region Lessons

            var lessons = new List<Lesson>()
            {
                new Lesson
                {
                    Cabinet = "101",
                    Theme = "Introduction to Algebra",
                    Description = "Understanding the basics of the process of photosynthesis.",
                    Duration = 60,
                    Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-A"),
                    LessonStartDate = new DateTime(2023, 12, 1, 1,0,0).ToUniversalTime(),
                    Subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Name == "Math"),
                    Teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Name == "John Smith" && x.Surname == "Johnson"),
                    Homeworks = new List<Homework>(),
                    Visitings = new List<Visiting>()
                },
                new Lesson
                {
                    Cabinet = "102",
                    Theme = "Newton's Laws of Motion",
                    Description = "Understanding the three laws of motion formulated by Sir Isaac Newton.",
                    Duration = 90,
                    Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-B"),
                    LessonStartDate = new DateTime(2023, 12, 1, 2,30,0).ToUniversalTime(),
                    Subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Name == "Physics"),
                    Teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Name == "Emily Davis" && x.Surname == "Miller"),
                    Homeworks = new List<Homework>(),
                    Visitings = new List<Visiting>()
                },
                new Lesson
                {
                    Cabinet = "103",
                    Theme = "Cell Division",
                    Description = "Exploring the process of cell division and its significance in living organisms.",
                    Duration = 75,
                    Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "2-A"),
                    LessonStartDate = new DateTime(2023, 12, 2,14,0,0).ToUniversalTime(),
                    Subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Name == "Biology"),
                    Teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Name == "Michael Garcia" && x.Surname == "Brown"),
                    Homeworks = new List<Homework>(),
                    Visitings = new List<Visiting>()
                },
                new Lesson
                {
                    Cabinet = "104",
                    Theme = "Atomic Structure",
                    Description = "Understanding the structure of atoms and their components.",
                    Duration = 90,
                    Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-A"),
                    LessonStartDate = new DateTime(2023, 10, 4).ToUniversalTime(),
                    Subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Name == "Chemistry"),
                    Teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Name == "Emma Wilson" && x.Surname == "Smith"),
                    Homeworks = new List<Homework>(),
                    Visitings = new List<Visiting>()
                },
                new Lesson
                {
                    Cabinet = "105",
                    Theme = "World War II",
                    Description = "Understanding the events, causes, and consequences of World War II.",
                    Duration = 60,
                    Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-B"),
                    LessonStartDate = new DateTime(2023, 10, 5).ToUniversalTime(),
                    Subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Name == "History"),
                    Teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Name == "Daniel Martinez" && x.Surname == "Johnson"),
                    Homeworks = new List<Homework>(),
                    Visitings = new List<Visiting>()
                }

            };

            await _context.Lessons.AddRangeAsync(lessons);
            await _context.SaveChangesAsync();

            List<Lesson> lessonList = new List<Lesson>();
            DateTime baseLessonStartDate = new DateTime(2023, 12, 1, 14,0,0).ToUniversalTime();
            DateTime baseLessonStartDate2 = new DateTime(2023, 12, 1, 16,0,0).ToUniversalTime();

            for (int i = 0; i < 40; i++)
            {
                baseLessonStartDate = baseLessonStartDate.AddDays(1);

                if (baseLessonStartDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    baseLessonStartDate = baseLessonStartDate.AddDays(1); // Move to Monday
                }
                else if (baseLessonStartDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    baseLessonStartDate = baseLessonStartDate.AddDays(2); // Move to Monday
                }

                Lesson newLesson = new Lesson
                {
                    Cabinet = "101",
                    Theme = "Introduction to Algebra",
                    Description = "Understanding the basics of the process of photosynthesis.",
                    Duration = 60,
                    Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-A"),
                    LessonStartDate = baseLessonStartDate,
                    Subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Name == "Math"),
                    Teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Name == "John Smith" && x.Surname == "Johnson"),
                    Homeworks = new List<Homework>(),
                    Visitings = new List<Visiting>()
                };

                var newLesson2 = new Lesson
                {
                    Cabinet = "104",
                    Theme = "Atomic Structure",
                    Description = "Understanding the structure of atoms and their components.",
                    Duration = 90,
                    Group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == "1-A"),
                    LessonStartDate = baseLessonStartDate.AddHours(2),
                    Subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Name == "Chemistry"),
                    Teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Name == "Emma Wilson" && x.Surname == "Smith"),
                    Homeworks = new List<Homework>(),
                    Visitings = new List<Visiting>()
                };

                lessonList.Add(newLesson);
                lessonList.Add(newLesson2);
            }

            await _context.Lessons.AddRangeAsync(lessonList);
            await _context.SaveChangesAsync();


            var visitings = new List<Visiting>()
            {
                new Visiting
                {
                    isLate = true,
                    isPresent = true,
                    Lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.LessonStartDate == new DateTime(2023, 10, 5).ToUniversalTime() && x.Cabinet == "105"),
                    Student = await _context.Students.FirstOrDefaultAsync(x => x.Name == "Oliver" && x.Surname == "Garcia")
                }
            };

            await _context.Visitings.AddRangeAsync(visitings);
            await _context.SaveChangesAsync();
            #endregion








        }

    }
}
