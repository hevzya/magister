using Magister.DataAccess;
using Magister.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitingsController : ControllerBase
    {
        private readonly MagisterContext _db;
        public VisitingsController(MagisterContext db)
        {
            _db = db;
        }

        public async Task<ICollection<VisitingModel>> GetVisitings(Guid? lessonId, Guid? studentId) 
        {
            var query = _db.Visitings.AsQueryable();

            if (lessonId != null)
            {
                query = query.Where(x => x.LessonId == lessonId);
            }

            if (studentId != null)
            {
                query = query.Where(x => x.StudentId == studentId);
            }

            return await query.Select(x => new VisitingModel
            {
                LessonId = x.LessonId,
                StudentId = x.StudentId,
                ExamMark = x.ExamMark,
                Id = x.Id,
                isLate = x.isLate,
                isPresent = x.isPresent,
                LessonMark = x.LessonMark

            }).ToListAsync();
                
        }


        [HttpPost]
        public async Task AddVisiting([FromBody] VisitingModel visiting)
        {
            var existing = _db.Visitings.FirstOrDefault(x => x.StudentId == visiting.StudentId && x.LessonId == visiting.LessonId);

            if (existing == null)
            {
                _db.Visitings.Add(new DataAccess.Entities.Visiting
                {
                    ExamMark = visiting.ExamMark,
                    isLate = visiting.isLate,
                    LessonId = visiting.LessonId,
                    StudentId = visiting.StudentId,
                    isPresent = visiting.isPresent,
                    LessonMark = visiting.LessonMark,
                });
            } else
            {
                existing.ExamMark = visiting.ExamMark;
                existing.isLate = visiting.isLate;
                existing.isPresent = visiting.isPresent;
                existing.LessonMark = visiting.LessonMark;
            }

            
            await _db.SaveChangesAsync();
        }
    }
}
