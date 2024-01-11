using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RecruitmentEntity:BaseEntity
    {
        public string? RecruitmentType { set; get; }
        public string? RecruitmentPhoneNumber { set; get; }
        public string? RecruitmentAddress { set; get; }
        public string? RecruitmentDescription { set; get; }
        public string? RecruitmentTitle { set; get; }
        public string? RecruitmentImage { set; get; }
        public Guid? UserId { set; get; }
        public UserEntity? User { set; get; }
        public Guid? ProvinceId { set; get; }
        public ProvinceEntity? Province { set; get; }
        public Guid? CityId { set; get; }
        public CityEntity? City { set; get; }
        public ConditionEnum Condition { set; get; }
    }
}
