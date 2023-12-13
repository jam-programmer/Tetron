using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserAddressEntity:BaseEntity
    {
        public Guid CountryId { set; get; }
        public CountryEntity? Country { get; set; }

        public Guid ProvinceId { set; get; }
        public ProvinceEntity? Province { get; set; }

        public Guid CityId { set; get; }
        public CityEntity? City { get; set; }   

        public Guid UserId { set; get; }
        public UserEntity? User { set; get; }
    }
}
