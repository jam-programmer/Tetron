using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class IntroductionMapping : IEntityTypeConfiguration<IntroductionEntity>
    {
        public void Configure(EntityTypeBuilder<IntroductionEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.IntroductionTitle).IsRequired();
            builder.Property(p => p.IntroductionDescription).IsRequired();
            builder.Property(p => p.IntroductionImage).IsRequired();
            builder.HasMany(m => m.SkillIntroduction)
                .WithOne(o => o.Introduction)
                .HasForeignKey(f => f.IntroductionId);
        }
    }
}
