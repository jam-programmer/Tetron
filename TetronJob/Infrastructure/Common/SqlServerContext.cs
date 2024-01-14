using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Common
{
    public class SqlServerContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> option) : base(option)
        {

        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        #region Entities
        public virtual DbSet<CategoryEntity> Category { get; set; }
        public virtual DbSet<CityEntity> City { get; set; }

        public virtual DbSet<ProvinceEntity> Province { get; set; }
        public virtual DbSet<UserAddressEntity> UserAddress { get; set; }
        public virtual DbSet<CategoryUserEntity> CategoryUser { get; set; }
        public virtual DbSet<IntroductionEntity> Introduction { get; set; }
        public virtual DbSet<PictureEntity> Picture { get; set; }
        public virtual DbSet<PlacementEntity> Placement { get; set; }
        public virtual DbSet<RecruitmentEntity> Recruitment { get; set; }
        public virtual DbSet<SkillEntity> Skill { get; set; }
        public virtual DbSet<SkillIntroductionEntity> SkillIntroduction { get; set; }





        #endregion
    }
}
