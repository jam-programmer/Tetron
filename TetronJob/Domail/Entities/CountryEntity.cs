using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class CountryEntity:BaseEntity,IBase
    {
        public string? Name { set; get; }
        public ICollection<ProvinceEntity>? Provinces { set; get; }   
        public ICollection<UserAddressEntity>? UserAddress { set; get; }
        public DateTime UpdateTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
