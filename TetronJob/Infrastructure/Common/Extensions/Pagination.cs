using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Extensions
{
    public class Pagination
    {
        public int Index;
        public int Size;

        public int PageIndex
        {
            get => Index;
            set => Size = value >= 0 ? value : 1;
        }

        public int PageSize
        {
            get => Index;
            set => Size = value >= 0 ? value : 10;
        }
    }
    public class PaginationWithSearch
    {
        private int _pageIndex;
        private int _pageSize;
        private string? _search;

        public string? Search
        {
            get => _search;
            set => _search = string.IsNullOrEmpty(value) ? string.Empty : value;
        }

        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value >= 0 ? value : 1;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value >= 0 ? value : 10;
        }
    }
}
