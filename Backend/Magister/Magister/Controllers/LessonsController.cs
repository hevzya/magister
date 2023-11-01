using Magister.DataAccess;
using Magister.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magister.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly MagisterContext _db;
        public LessonsController(MagisterContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<LessonModel>> GetLessons()
        {
            return await _db.Lessons.Select(x => new LessonModel
            {
                Id = x.Id,
                Cabinet = x.Cabinet,
                Description = x.Description,
                Duration = x.Duration,
                LessonStartDate = x.LessonStartDate,
                Theme = x.Theme
            }).ToListAsync();
        }


    }
}
