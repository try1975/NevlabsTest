using System;

namespace Try1975.Nevlabs.Entities
{
    public class PersonEntity : IEntity<int>
    {
        public string Fullname { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        public int Id { get; set; }
    }
}