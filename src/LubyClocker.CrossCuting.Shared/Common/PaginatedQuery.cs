using System.Linq;
using MediatR;

namespace LubyClocker.CrossCuting.Shared.Common
{
    public class PaginatedQuery<T> : IRequest<PaginatedResult<T>>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}