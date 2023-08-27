using Magister.DataAccess;
using Magister.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Magister.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet(Name="AddSubject")]
        public void AddSubject()
        {
            var subject = new Subject
            {
                Name = "Math",
                TeacherName = "Vasyan"
            };

            using (var db = new MagisterContext())
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
            }
        }

        [HttpGet(Name = "GetSubjects")]
        public List<Subject> GetSubjects(string subjectName)
        {
            using (var db = new MagisterContext())
            {
                return db.Subjects.Where(x => x.Name == subjectName).ToList();
            }
        }

    }
}
