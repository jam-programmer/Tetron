using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Common;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConnectionOptions = Infrastructure.Common.ConnectionOptions;

namespace Infrastructure.Configuration
{
    public static class ConfigureServices
    {
        public static IServiceCollection InfrastructureConfiguration
        (this IServiceCollection services,
            IConfiguration configuration)
        {
            ConnectionOptions.ConnectionString = configuration.GetConnectionString("TetronJob");

            services.AddIdentity<UserEntity, RoleEntity>().AddEntityFrameworkStores<SqlServerContext>()
                .AddRoles<RoleEntity>()
                .AddDefaultTokenProviders();

            services.AddDbContext<SqlServerContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("TetronJob"));
            });
            services.AddScoped<IDapper, Persistence.Repositories.Dapper>();
            //services.AddScoped<ISqlServer>(provider => provider.GetRequiredService<DataBaseContext>());
            services.AddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
            //services.AddScoped(typeof(IDapper<>), typeof(DapperRepository<>));
            //ConnectionOptions.ConnectionString = configuration.GetConnectionString("DonyshDataBase");
            return services;
        }
    }
}
