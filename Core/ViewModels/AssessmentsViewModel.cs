using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class AssessmentsViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int NumberStar { get; set; }
        public int IdProject { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
