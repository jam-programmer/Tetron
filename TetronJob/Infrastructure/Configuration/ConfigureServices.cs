using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Common;

namespace Infrastructure.Configuration
{
    public static class ConfigureServices
    {
        public static IServiceCollection InfrastructureConfiguration
        (this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddIdentity<UserEntity, RoleEntity>().AddEntityFrameworkStores<SqlServerContext>()
                .AddRoles<RoleEntity>()
                .AddDefaultTokenProviders();

            services.AddDbContext<SqlServerContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("TetronJob"));
            });
            //services.AddScoped<ISqlServer>(provider => provider.GetRequiredService<DataBaseContext>());
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped(typeof(IDapper<>), typeof(DapperRepository<>));
            //ConnectionOptions.ConnectionString = configuration.GetConnectionString("DonyshDataBase");
            return services;
        }
    }
}
