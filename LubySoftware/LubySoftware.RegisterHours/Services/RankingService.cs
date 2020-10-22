using LubySoftware.Domain.Models;
using LubySoftware.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubySoftware.RegisterHours.Services
{
    public class RankingService
    {
        readonly IRegisterHoursRepository RegisterHoursRepository;
        readonly IPersonRepository PersonRepository;

        public RankingService(
            IRegisterHoursRepository registerHoursRepository,
            IPersonRepository personRepository
        )
        {
            RegisterHoursRepository = registerHoursRepository;
            PersonRepository = personRepository;
        }

        public async Task<IEnumerable<PersonModel>> FindTopFiveDevelopers()
        {
            IEnumerable<RegisterHourModel> lstRegisterHours = await RegisterHoursRepository.FindAll();
            IList<RankingModel> lstRranking = ProcessRanking(lstRegisterHours);
            return await FindPerson(lstRranking);
        }

        private IList<RankingModel> ProcessRanking(IEnumerable<RegisterHourModel> lstRegisterHours)
        {
            IList<RankingModel> lstRranking = new List<RankingModel>();

            foreach (var registerHoursGroup in lstRegisterHours.GroupBy(g => g.DeveloperId))
            {
                int totalMinutes = (int)lstRegisterHours
                    .Where(w => w.DeveloperId == registerHoursGroup.Key)
                    .Sum(s => (s.EndDateTime - s.StartDateTime).TotalMinutes);

                int totalRegisters = lstRegisterHours
                    .Where(w => w.DeveloperId == registerHoursGroup.Key)
                    .Count();

                lstRranking.Add(new RankingModel
                {
                    DeveloperId = registerHoursGroup.Key,
                    Total = totalMinutes / totalRegisters
                });
            }

            return lstRranking;
        }

        private async Task<IList<PersonModel>> FindPerson(IList<RankingModel> lstRranking)
        {
            IList<PersonModel> lstPerson = new List<PersonModel>();
            foreach (var ranking in lstRranking.OrderByDescending(od => od.Total).Take(5))
            {
                lstPerson.Add(await PersonRepository.Find(ranking.DeveloperId));
            }

            return lstPerson;
        }
    }
}
