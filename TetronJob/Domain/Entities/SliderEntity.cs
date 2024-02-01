using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class SliderEntity:BaseEntity
    {
        public string? SliderImagePath { set; get; }
        public string? SliderAlt { set; get; }
        public string? SliderLink { set; get; }
        public PositionEnum? Position { set; get; }
    }
}
