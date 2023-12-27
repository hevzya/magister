namespace Magister.DataAccess.Entities
{
    public class Homework
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FileUrl { get; set; }
        public string Description { get; set; }


        public DateTime CreatedDate { get; set; }
        public DateTime Deadline { get; set; }

        public Guid? LessonId { get; set; }

        public Lesson Lesson { get; set; }
        public ICollection<StudentHomework> StudentHomeworks { get; set; }

    }
}
