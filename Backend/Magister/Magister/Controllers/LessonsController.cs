using Magister.DataAccess;
using Magister.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Magister.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonsController : ODataController
    {
        private readonly MagisterContext _db;
        public LessonsController(MagisterContext db)
        {
            _db = db;
        }

        [EnableQuery]
        public IQueryable<Lesson> Get() 
        {
            return _db.Lessons;
        }


        //[HttpGet]
        //public async Task<List<LessonModel>> GetLessons()
        //{
        //    return await _db.Lessons.Select(x => new LessonModel
        //    {
        //        Id = x.Id,
        //        Cabinet = x.Cabinet,
        //        Description = x.Description,
        //        Duration = x.Duration,
        //        LessonStartDate = x.LessonStartDate,
        //        Theme = x.Theme
        //    }).ToListAsync();
        //}


    }
}
