using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class ProvinceEntity:BaseEntity,IBase
    {
        public string? Name { set; get; }



        #region ForeginKey

        public ICollection<CityEntity>? Cities { set; get; }
        public ICollection<UserAddressEntity>? UserAddress { set; get; }


        #endregion


        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
