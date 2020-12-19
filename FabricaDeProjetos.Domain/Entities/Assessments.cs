using System;
using System.Collections.Generic;
using System.Text;

namespace FabricaDeProjetos.Domain.Entities
{
    public class Assessments : BaseEntitie
    {
        public int NumberStar { get; set; }
        public int IdProject { get; set; }
    }
}
