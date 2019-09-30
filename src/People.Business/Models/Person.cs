using System;

namespace People.Business.Models
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public DateTime Birthdate { get; set; }
        public string WhatsAppNumber { get; set; }
    }
}
