using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Common
{
    public class SqlServerContext : IdentityDbContext<UserEntity,RoleEntity,Guid>
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> option) : base(option)
        {

        }

        #region Entities
        public virtual DbSet<CategoryEntity> Category { get; set; } 
        public virtual DbSet<CityEntity> City { get; set; }
        public virtual DbSet<CountryEntity> Country { get; set; }   
        public virtual DbSet<ProvinceEntity> Province { get; set; }
        public virtual DbSet<UserAddressEntity> UserAddress { get; set; }   
  


        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
