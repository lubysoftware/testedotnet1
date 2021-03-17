using LTS.Domain.Base;
using LTS.Domain.Commands;
using System;
using System.Threading.Tasks;

namespace LTS.Domain.Interfaces
{
    public interface IProjectService 
    {
        Task<GenericCommandResult> GetAllPaginated(PaginationParameters paginationParameters);
        Task<GenericCommandResult> GetById(Guid projectId);
    }
}
