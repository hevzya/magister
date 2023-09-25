using Magister.DataAccess;
using Magister.DataAccess.Entities;
using Magister.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magister.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController
    {
        private readonly MagisterContext _db;
        public StudentsController(MagisterContext db) 
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<StudentModel>> GetStudents()
        {
            return await _db.Users.Select(x => new StudentModel
            {
                Address = x.Address,
                Age = x.Age,
                Email = x.Email,
                Gender = x.Gender,
                Name = x.UserName,
                PhoneNumber = x.PhoneNumber
            }).ToListAsync();
        }
    }
}
