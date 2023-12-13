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
    public class CategoryMapping : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.Color).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            
        }
    }
}
