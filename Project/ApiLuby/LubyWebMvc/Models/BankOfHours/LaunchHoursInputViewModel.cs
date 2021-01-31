using System;
using System.ComponentModel.DataAnnotations;

namespace LubyWebMvc.Models.BankOfHours
{
    public class LaunchHoursInputViewModel
    {   [Required(ErrorMessage = "A data de entrada é obrigatória")]
        public DateTime EntryDate { get; set; }
        [Required(ErrorMessage = "A data de saída é obrigatória")]
        public DateTime FinalDate { get; set; }
        public double TotalHours { get; set; }
        //{
        //    get
        //    {
        //        TimeSpan value = FinalDate.Subtract(EntryDate);
        //        return value.TotalHours;
        //    }

        //}
    }
}


