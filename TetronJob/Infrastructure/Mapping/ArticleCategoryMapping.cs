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
    public class ArticleCategoryMapping:IEntityTypeConfiguration<ArticleCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ArticleCategoryEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(m => m.Article)
                .WithOne(o => o.Category)
                .HasForeignKey(f => f.ArticleCategoryId);
        }
    }
}
