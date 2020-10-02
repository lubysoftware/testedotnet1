using System;
using System.Collections.Generic;
using System.Text;
using TesteLuby.Domain.Attributes;

namespace TesteLuby.Domain.Models.Entities
{
    [Entity("businesshour", "System businesshour", true)]
    public class BusinessHour : EntityModels
    {
        public string DeveloperId { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }

    }
}
