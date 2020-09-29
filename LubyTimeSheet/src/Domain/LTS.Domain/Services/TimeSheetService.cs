using LTS.Domain.Base;
using LTS.Domain.Commands;
using LTS.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LTS.Domain.Services
{
    public class TimeSheetService : ITimeSheetService
    {
        private readonly ITimeSheetRepository _timeSheetRepository;


        public TimeSheetService(ITimeSheetRepository timeSheetRepository)
        {
            _timeSheetRepository = timeSheetRepository;
        }

        public async Task<GenericCommandResult> GetAllPaginated(PaginationParameters paginationParameters)
        {
            var data = await _timeSheetRepository.GetProjectsPaginated(paginationParameters);

            return new GenericCommandResult(true, "Lista retornada com sucesso", data.OrderBy(x => x.DateBegin));
        }

        public async Task<GenericCommandResult> GetById(Guid id)
        {
            var data = await _timeSheetRepository.GetByIdAsync(id);

            if (data == null)
                return new GenericCommandResult(false, "Apontamento não encontrado");

            return new GenericCommandResult(true, "Apontamento retornado com sucesso", data);
        }
    }
}

