using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiLuby.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
    }
}
