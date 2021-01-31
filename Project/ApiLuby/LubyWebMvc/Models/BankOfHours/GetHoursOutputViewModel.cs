using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubyWebMvc.Models.BankOfHours
{
    public class GetHoursOutputViewModel
    {
        public DateTime EntryDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string Login { get; set; }
        public int TotalHours { get; set; }
    }
}
