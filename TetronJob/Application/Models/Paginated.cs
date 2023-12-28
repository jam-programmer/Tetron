using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Paginated
    {
        private int _page;
        public int Page
        {
            get { return _page; }
            set { _page = value < 1 ? 1 : value; }
        }
    }
}
