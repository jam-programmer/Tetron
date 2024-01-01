using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class UserAddressMapping:IEntityTypeConfiguration<UserAddressEntity>
    {
        public void Configure(EntityTypeBuilder<UserAddressEntity> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(o => o.City)
                .WithMany(m => m.UserAddress)
                .HasForeignKey(f => f.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Province)
                .WithMany(m => m.UserAddress)
                .HasForeignKey(f => f.ProvinceId)
                .OnDelete(DeleteBehavior.NoAction);

          
        }
    }
}
