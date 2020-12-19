using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FabricaDeProjetos.Domain.Entities
{
    public abstract class BaseEntitie
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
