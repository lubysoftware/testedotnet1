using System.Collections.Generic;

namespace ApiLuby.Business.Entities.Repositories
{
    public interface IBankOfHoursRepository
    {
        void Add(BankOfHours bankOfHours);

        void Commit();

        IList<BankOfHours> GetPerDeveloper(int codigoDeveloper);

        IList<BankOfHours> GetRank(int codigoDeveloper);
        List<BankOfHoursVM> GetTotalHours(int developerCode);


        //public Double GetRank();
    }
}
