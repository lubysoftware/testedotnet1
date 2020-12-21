using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? IdDeveloper { get; set; }
        public bool Active { get; set; }
        public string InitialDate { get; set; }
        public string? FinalDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
