namespace Magister.DataAccess.Entities
{
    public class StudentHomework
    {
        public Guid Id { get; set; }
        public string File { get; set; }
        public int Mark { get; set; }


        public Homework Homework { get; set; }
        public Student Student { get; set; }
    }
}
