using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiLuby.Models
{
    public class Project
    {
        public Guid id { get; set; }
        public String Name { get; set; }
        public int EstimatedHours { get; set; }
    }
}
