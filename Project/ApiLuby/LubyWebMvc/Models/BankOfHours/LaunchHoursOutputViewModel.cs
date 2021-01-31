using System;
using System.ComponentModel.DataAnnotations;

namespace LubyWebMvc.Models.BankOfHours
{
    public class LaunchHoursOutputViewModel
    {   
        public DateTime EntryDate { get; set; }
        
        public DateTime FinalDate { get; set; }

        public double TotalHours { get; set; }  //será que tenho que definir aquele set pra fazer o calculo tb???
    }
}

