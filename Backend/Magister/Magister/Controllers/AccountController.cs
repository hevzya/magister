using Magister.DataAccess;
using Magister.DataAccess.Entities;
using Magister.Models.Requests;
using Magister.Models.Results;
using Magister.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Magister.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IJwtService _jwtService;
        private readonly MagisterContext _db;

        public AccountController(
            SignInManager<User> signInManager,
            MagisterContext db,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IJwtService jwtService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtService = jwtService;
            _roleManager = roleManager;
            _db = db;
        }

        // https://localhost:7211/api/Account/Login
        [HttpPost]
        public async Task<LoginResult> LoginAsync(LoginRequest model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(r => r.Email == model.Email);

            if (user == null)
            {
                throw new Exception($"There is not user with email {model.Email}");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);

            if (!result.Succeeded) // result.Succeeded != true
            {
                throw new Exception("Something get wrong");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtService.GenerateJwtToken(user.Email, user.Id, user.UserName, roles);

            //var refreshToken = await _jwtService.GenerateRefreshToken(user.Id);

            return new LoginResult
            {
                AccessToken = token
            };
        }

        [HttpPost]
        public async Task<string> CreateUserAsync(CreateUserRequest model)
        {
            var isRoleExists = await _roleManager.RoleExistsAsync(model.Role);

            if (!isRoleExists)
            {
                return $"There is no {model.Role} role in the database";
            }

            var existingUser = await _userManager.FindByEmailAsync(model.Email);

            if(existingUser is not null)
            {
                return $"User with email {model.Email} already exists";
            }

            var group = await _db.Groups.FirstOrDefaultAsync(x => x.GroupName == model.GroupName);

            if(group == null)
            {
                var newGroup = await _db.Groups.AddAsync(new Group
                {
                    GroupName = model.GroupName
                });
                await _db.SaveChangesAsync();

                group = await _db.Groups.FirstOrDefaultAsync(x => x.GroupName == model.GroupName);
            }

            var res = await _userManager.CreateAsync(new User
            {
                Email = model.Email,
                UserName = model.Name,
                PhoneNumber = model.PhoneNumber,
                Student = new Student
                {
                    DateOfBirth = DateTime.Parse(model.DateOfBirth),
                    GroupId = group.Id,
                    Name = model.FirstName,
                    Surname = model.SecondName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address
                }
            }, model.Password);

            var createdUser = await _userManager.FindByEmailAsync(model.Email);
            await _userManager.AddToRoleAsync(createdUser, model.Role);

            


            if (res.Succeeded)
            {
                return $"User {model.Name} with role {model.Role} has been created";
            } else
            {
                return res.Errors.Select(c => c.Description).Aggregate((x,y) => x + "; " + y);
            }
        }


    }
}
