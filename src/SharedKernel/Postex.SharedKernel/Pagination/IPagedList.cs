using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.SharedKernel.Pagination
{
    public interface IPagedList<T>
    {
        int IndexFrom { get; }

        int PageIndex { get; }

        int PageSize { get; }

        int TotalCount { get; }

        int TotalPages { get; }

        IList<T> Items { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }
    }
}
