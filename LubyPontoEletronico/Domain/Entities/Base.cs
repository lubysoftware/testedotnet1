using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public Base()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
