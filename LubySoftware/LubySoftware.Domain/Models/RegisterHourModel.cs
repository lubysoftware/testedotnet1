using System;

namespace LubySoftware.Domain.Models
{
    public class RegisterHourModel
    {
        public long Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public long DeveloperId { get; set; }

        public PersonModel Developer { get; set; }
    }
}
