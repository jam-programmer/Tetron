using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class CityEntity:BaseEntity , IBase
    {
        public string? Name { set; get; }


        #region ForeginKey
        public Guid ProvinceId { set; get; }
        public ProvinceEntity? Province { set; get; }   
        public ICollection<UserAddressEntity>? UserAddress { set; get; }
        public DateTime UpdateTime { get ;
            set ; }
        public bool IsDeleted { get;
            set ; }

        #endregion

    }
}
