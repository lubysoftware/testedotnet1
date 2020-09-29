using LTS.Domain.Base;
using LTS.Domain.Commands;
using LTS.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LTS.Domain.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<GenericCommandResult> GetAllPaginated(PaginationParameters paginationParameters)
        {
            var data = await _projectRepository.GetProjectsPaginated(paginationParameters);

            return new GenericCommandResult(true, "Lista retornada com sucesso", data.OrderBy(x => x.Name));
        }
        public async Task<GenericCommandResult> GetById(Guid id)
        {
            var data = await _projectRepository.GetByIdAsync(id);

            if (data == null)
                return new GenericCommandResult(false, "Projeto não encontrado");

            return new GenericCommandResult(true, "Projeto retornado com sucesso", data);
        }
    }
}
