using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class PaginatedSearch
    {
        public string? Keyword { get; set; }

        private int _page = 1;
        public int Page
        {
            get { return _page; }
            set { _page = value < 1 ? 1 : value; }
        }
    }
}
