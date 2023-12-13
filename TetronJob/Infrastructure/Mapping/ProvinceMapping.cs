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
    public class ProvinceMapping : IEntityTypeConfiguration<ProvinceEntity>
    {
        public void Configure(EntityTypeBuilder<ProvinceEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.HasMany(m => m.Cities)
                .WithOne(o => o.Province)
                .HasForeignKey(f => f.ProvinceId);
        }
    }
}
