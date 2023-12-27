using Magister.DataAccess.Entities;
using Magister.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly MagisterContext _db;
        private readonly IWebHostEnvironment _env;

        public HomeworkController(MagisterContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm]IFormFile file, [FromQuery]string description, [FromQuery] DateTime deadline, [FromQuery] Guid lessonId) 
        {
            Homework homework = new Homework();


            var fileType = Path.GetExtension(file.FileName);

            var filePath = _env.ContentRootPath;
            var docName = Path.GetFileName(file.FileName);
            if (file != null && file.Length > 0)
            {
                homework.Id = Guid.NewGuid();
                homework.Name = docName;
                homework.CreatedDate = DateTime.Now;
                homework.Deadline = new DateTime(deadline.Year,deadline.Month,deadline.Day);
                homework.Description = description;
                homework.LessonId = lessonId;

                var directoryPath = Path.Combine(filePath, "Files");

                Directory.CreateDirectory(directoryPath);

                homework.FileUrl = Path.Combine(directoryPath, homework.Id.ToString() + fileType);

                using (var stream = new FileStream(homework.FileUrl, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                await _db.Homeworks.AddAsync(homework);
                await _db.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }


            return Ok();
        }

    }
}
