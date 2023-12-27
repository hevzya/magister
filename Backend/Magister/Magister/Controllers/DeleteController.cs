using Magister.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magister.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly MagisterContext _db;
        public DeleteController(MagisterContext db)
        {
            _db = db;
        }

        [HttpDelete]
        public async Task DeleteStudent([FromQuery] Guid studentId)
        {
            var data = await _db.Students.FirstOrDefaultAsync(x => x.Id == studentId);

            if (data == null)
            {
                return;
            }

            _db.Students.Remove(data);
            await _db.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeleteLesson([FromQuery] Guid lessonId)
        {
            var data = await _db.Lessons.FirstOrDefaultAsync(x => x.Id == lessonId);

            if (data == null)
            {
                return;
            }

            _db.Lessons.Remove(data);
            await _db.SaveChangesAsync();
        }
    }
}
