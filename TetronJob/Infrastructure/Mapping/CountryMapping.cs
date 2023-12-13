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
    public class CountryMapping:IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.HasMany(m => m.Provinces)
                .WithOne(o => o.Country)
                .HasForeignKey(f => f.CountryId);
        }
    }
}
