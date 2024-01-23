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
    public class SliderMapping:IEntityTypeConfiguration<SliderEntity>
    {
        public void Configure(EntityTypeBuilder<SliderEntity> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}
