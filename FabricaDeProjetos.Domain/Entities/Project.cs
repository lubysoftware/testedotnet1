using System;
using System.Collections.Generic;
using System.Text;

namespace FabricaDeProjetos.Domain.Entities
{
    public class Project : BaseEntitie
    {
        public string Title { get; set; }
        public int IdDeveloper { get; set; }
        public bool Active { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
