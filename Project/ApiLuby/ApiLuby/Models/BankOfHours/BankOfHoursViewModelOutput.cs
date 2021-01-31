using System;
using System.ComponentModel.DataAnnotations;

namespace ApiLuby.Models.BankOfHours
{
    public class BankOfHoursViewModelOutput
    {
        
        public DateTime EntryDate { get; set; }
        
        public DateTime FinalDate { get; set; }
        public string Login { get; set; }
       public double TotalHours { get; set; }



       
    }

  }

