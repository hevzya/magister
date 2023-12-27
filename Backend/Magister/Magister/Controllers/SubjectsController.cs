using Magister.DataAccess;
using Magister.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly MagisterContext _db;
        public SubjectsController(MagisterContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> GetSubjectsByUserId(Guid userId)
        {
            var user = await _db.Users.Include(x => x.Student).SingleOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return BadRequest("No user with id: " + userId);
            }

            var groupId = user.Student?.GroupId;
            var studentId = user.Student?.Id;

            if (groupId == null)
            {
                return BadRequest("User with id: " + userId + " doesn't have group");
            }

            var lessons = await _db.Lessons
                .Include(x => x.Group)
                .Include(x => x.Visitings)
                .Include(x => x.Subject)
                .Where(x => x.Group.Id ==  groupId).ToListAsync();

            var subjects = lessons.Select(x => x.Subject.Name).Distinct().ToList().Select(x => new SubjectModel
            {
                Name = x,
                ExamMarks = new List<MarksModel>(),
                LessonMarks = new List<MarksModel>()
            }).ToList();

            foreach (var subject in subjects)
            {
                foreach(var lesson in lessons)
                {
                    if(lesson.Subject.Name == subject.Name)
                    {
                        var visiting = lesson.Visitings.FirstOrDefault(x => x.StudentId == studentId);

                        if(visiting != null && visiting?.LessonMark != null)
                        {
                            subject.LessonMarks.Add(new MarksModel
                            {
                                Mark = visiting.LessonMark,
                                Date = lesson.LessonStartDate,
                                isPresent = visiting.isPresent,
                                isLate = visiting.isLate,
                            });
                        }

                        if (visiting?.ExamMark != null)
                        {
                            subject.ExamMarks.Add(new MarksModel
                            {
                                Mark = visiting.ExamMark,
                                Date = lesson.LessonStartDate,
                                isPresent = visiting.isPresent,
                                isLate = visiting.isLate,
                            });
                        }

                    }
                }
            }

            return Ok(subjects);

        }

    }
}
