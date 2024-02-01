using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class SliderMapping : IEntityTypeConfiguration<SliderEntity>
    {
        public void Configure(EntityTypeBuilder<SliderEntity> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}
