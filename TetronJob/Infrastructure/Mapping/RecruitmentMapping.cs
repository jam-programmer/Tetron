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
    public class RecruitmentMapping:IEntityTypeConfiguration<RecruitmentEntity>
    {
        public void Configure(EntityTypeBuilder<RecruitmentEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.RecruitmentAddress).IsRequired();
            builder.Property(p => p.RecruitmentDescription).IsRequired();
            builder.Property(p => p.RecruitmentImage).IsRequired();
            builder.Property(p => p.RecruitmentPhoneNumber).IsRequired();
            builder.Property(p => p.RecruitmentTitle).IsRequired();
        }
    }
}
