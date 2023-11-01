namespace Magister.DataAccess.Entities
{
    public class Visiting
    {
        public Guid Id { get; set; }
        public bool isPresent { get; set; }
        public bool isLate { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
    }
}
