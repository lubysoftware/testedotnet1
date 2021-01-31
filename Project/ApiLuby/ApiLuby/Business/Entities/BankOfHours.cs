using System;

namespace ApiLuby.Business.Entities
{
    public class BankOfHours
    {
        public int Codigo { get; set; }
        public int CodigoDeveloper { get; set; }
        public virtual Developer Developer { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime FinalDate { get; set; }
        public double TotalHours { get; set; }



    }
}
