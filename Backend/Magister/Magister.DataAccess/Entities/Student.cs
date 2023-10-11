using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magister.DataAccess.Entities
{
    public class Student
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

        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
