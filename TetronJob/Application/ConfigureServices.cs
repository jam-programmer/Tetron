using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Reports.Role;
using Application.Reports.User;
using Application.Services.Role;
using Application.Services.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection ApplicationConfiguration
            (this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IRoleReport,RoleReport>()
                .AddScoped<IRoleService,RoleService>();

            services.AddScoped<IUserReport, UserReport>()
                .AddScoped<IUserService, UserService>();


            return services;
        }
    }
}
