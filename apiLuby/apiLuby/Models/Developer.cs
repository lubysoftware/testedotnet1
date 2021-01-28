using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiLuby.Models
{
    public class Developer
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public String Password { get; set; }
        public bool Active { get; set; }
    }
}
