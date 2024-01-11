using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
   
    public interface IBase
    {
        DateTime UpdateTime { get; set; }
        bool IsDeleted { get; set; }
    }
   
}
