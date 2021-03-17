using LTS.Domain.Base;
using LTS.Domain.Commands;
using LTS.Domain.Interfaces;
using LTS.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTS.Domain.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task<GenericCommandResult> GetAllPaginated(PaginationParameters paginationParameters)
        {
            var data = await _developerRepository.GetDevelopersPaginated(paginationParameters);

            return new GenericCommandResult(true, "Lista retornada com sucesso", data.OrderBy(x => x.Name));
        }

        public async Task<GenericCommandResult> GetById(Guid id)
        {
            var data = await _developerRepository.GetByIdAsync(id);

            if (data == null)
                return new GenericCommandResult(false, "Desenvolvedor não encontrado");

            return new GenericCommandResult(true, "Desenvolvedor retornado com sucesso", data);
        }

        public async Task<GenericCommandResult> GetDeveloperWithHours()
        {

            var developersDb = await _developerRepository.GetAllWithHoursAsync();

            int dayOfWeek = (int)DateTime.Now.DayOfWeek;

            var response = new List<DeveloperHoursWorkedResponse>();

            foreach (var developer in developersDb)
            {

                var date = DateTime.UtcNow.Date.AddDays(-dayOfWeek);

                var hours = developer.TimeSheets
                    .Where(x => x.DateBegin.CompareTo(date) >= 0).Sum(x => x.TotalHours);

                var spam = TimeSpan.FromHours(hours);
                response.Add(new DeveloperHoursWorkedResponse
                {
                    Id = developer.Id,
                    Name = developer.Name,
                    TotalHourPerWeek = spam.ToString()
                });
            }

            var data = response.OrderByDescending(x => x.TotalHourPerWeek).Take(5);

            return new GenericCommandResult(true, "Lista retornada com sucesso", data);
        }
    }
}
