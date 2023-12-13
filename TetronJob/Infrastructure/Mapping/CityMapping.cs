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
    public class CityMapping : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
