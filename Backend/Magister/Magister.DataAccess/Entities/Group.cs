namespace Magister.DataAccess.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }


        public ICollection<Student> Students { get; set; }
        // public Teacher Supervisor { get; set; }
    }
}
