using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { set; get; }= Guid.NewGuid();
        public DateTime CreateTime { set; get; }=DateTime.Now;
    }

   
}
