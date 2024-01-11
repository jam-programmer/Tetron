using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PlacementEntity:BaseEntity
    {
        public string? PlacementFullName { set; get; }
        public string? PlacementNumber { set; get; }
        public string? PlacementDescription { set; get; }
        public string? PlacementImage { set; get; }
        public Guid? UserId { set; get; }
        public UserEntity? User { set; get; }
        public Guid? ProvinceId { set; get; }
        public ProvinceEntity? Province { set; get; }
        public Guid? CityId { set; get; }
        public CityEntity? City { set; get; }
        public ConditionEnum Condition { set; get; }
    }
}
