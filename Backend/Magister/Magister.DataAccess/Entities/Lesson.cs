namespace Magister.DataAccess.Entities
{
    public class Lesson
    {
        public Guid Id { get; set; }

        public DateTime LessonStartDate { get; set; }

        // in minutes
        public int Duration { get; set; }

        public string? Theme { get; set; }
        public string? Description { get; set; }

        public string? Cabinet { get; set; }

        public Group Group { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<Homework> Homeworks { get; set; }

    }
}
