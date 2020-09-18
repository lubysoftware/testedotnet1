using System.Collections.Generic;
using System.Linq;

namespace LubyClocker.CrossCuting.Shared.Common
{
    public class PaginatedResult<T>
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<T> Itens { get; set; }

        public PaginatedResult(int total, int page, int pageSize, List<T> itens)
        {
            Total = total;
            Page = page;
            PageSize = pageSize;
            Itens = itens;
        }
    }
}