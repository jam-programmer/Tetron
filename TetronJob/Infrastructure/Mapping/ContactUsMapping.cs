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
    public class ContactUsMapping:IEntityTypeConfiguration<ContactUsEntity>
    {
        public void Configure(EntityTypeBuilder<ContactUsEntity> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}
