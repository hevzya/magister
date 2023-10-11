namespace Magister.DataAccess.Entities
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? PlannedHours { get; set; }

        public ICollection<Lesson> Lessons { get; set;}
    }
}
