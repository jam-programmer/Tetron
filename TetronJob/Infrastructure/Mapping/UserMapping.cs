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
    public class UserMapping : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasMany(m => m.UserCategories)
                .WithOne(o => o.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(o => o.Address)
                .WithOne(o => o.User)
                .HasForeignKey<UserAddressEntity>(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
