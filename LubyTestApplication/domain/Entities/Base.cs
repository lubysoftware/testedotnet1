using System;
using System.ComponentModel.DataAnnotations;


namespace test.domain.Entities
{
    public abstract class Base
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
