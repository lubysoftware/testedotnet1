using System.Linq;
using System.Threading.Tasks;
using LubyClocker.CrossCuting.Shared.Common;
using Microsoft.EntityFrameworkCore;

namespace LubyClocker.Infra.Data.Extensions
{
    public static class QueryExtensions
    {
        public static async Task<PaginatedResult<T>> AsPaginated<T>(this IQueryable<T> query, int? page, int? pageSize)
        {
            page ??= 1;
            pageSize ??= 25;
            
            var skip = (page - 1) * pageSize;
            
            var total = await query.CountAsync();

            var list = await query
                .Skip(skip.Value)
                .Take(pageSize.Value)
                .ToListAsync();

            return new PaginatedResult<T>(total, page.Value, pageSize.Value, list);
        }
    }
}