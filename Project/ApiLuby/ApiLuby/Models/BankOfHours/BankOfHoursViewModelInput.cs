using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLuby.Models.BankOfHours
{
    public class BankOfHoursViewModelInput
    {
        public DateTime EntryDate { get; set; }
        public DateTime FinalDate { get; set; }
        public double TotalHours
        {

            get
            {
                TimeSpan value = FinalDate.Subtract(EntryDate);
                return value.TotalHours;
            }

        }
    }
}
    
