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
    public class PlacementMapping:IEntityTypeConfiguration<PlacementEntity>
    {
        public void Configure(EntityTypeBuilder<PlacementEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.PlacementFullName).IsRequired();
            builder.Property(p => p.PlacementImage).IsRequired();
            builder.Property(p => p.PlacementNumber).IsRequired();
        }
    }
}
