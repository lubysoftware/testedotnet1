using System;
using System.ComponentModel.DataAnnotations;


namespace test.domain.Entities
{
    public abstract class Base
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
