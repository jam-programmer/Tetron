using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class IntroductionEntity:BaseEntity
    {
        public string? IntroductionPhoneNumber { set; get; }
        public string? IntroductionTitle { set; get; }
        public string? IntroductionImage { set; get; }
        public string? IntroductionDescription { set; get; }
        public Guid? UserId { set; get; }
        public UserEntity? User { set; get; }
        public Guid? ProvinceId { set; get; }
        public ProvinceEntity? Province { set; get; }
        public Guid? CityId { set; get; }
        public CityEntity? City { set; get; }
        public ConditionEnum Condition { set; get; }

        public ICollection<SkillIntroductionEntity>? SkillIntroduction { set; get; }
    }
}
