using Magister.DataAccess;
using Magister.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Magister.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ODataController
    {
        private readonly MagisterContext _db;
        public StudentsController(MagisterContext db) 
        {
            _db = db;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<Student> GetStudents()
        {
            return _db.Students;

            //return await _db.Users.Select(x => new StudentModel
            //{
            //    Address = x.Address,
            //    Age = x.Age,
            //    Email = x.Email,
            //    Gender = x.Gender,
            //    Name = x.UserName,
            //    PhoneNumber = x.PhoneNumber
            //}).ToListAsync();
        }
    }
}
