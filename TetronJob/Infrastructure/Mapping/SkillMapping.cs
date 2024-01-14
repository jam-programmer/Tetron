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
    public class SkillMapping:IEntityTypeConfiguration<SkillEntity>
    {
        public void Configure(EntityTypeBuilder<SkillEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasMany(m => m.SkillIntroduction)
                .WithOne(o => o.Skill)
                .HasForeignKey(f => f.SkillId);
        }
    }
}
