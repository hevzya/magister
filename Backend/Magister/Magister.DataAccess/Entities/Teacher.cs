namespace Magister.DataAccess.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; }

        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string? Surname { get; set; }
        public string? Name { get; set; }

        // м. Рівне, Соборна 322, кв 69
        public string? Address { get; set; }



        public Guid UserId { get; set; }
        public User User { get; set; }

        // TODO: Supervisor
        // public Group Group { get; set; }
    }
}
