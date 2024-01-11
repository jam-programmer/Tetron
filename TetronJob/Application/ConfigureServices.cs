using System;
using System.Collections.Generic;

using Application.Reports.Category;
using Application.Reports.CategoryUser;
using Application.Reports.City;
using Application.Reports.Province;
using Application.Reports.Role;
using Application.Reports.User;
using Application.Reports.UserAddress;
using Application.Services.Category;
using Application.Services.CategoryUser;
using Application.Services.City;
using Application.Services.Province;
using Application.Services.Role;
using Application.Services.User;
using Application.Services.UserAddress;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection ApplicationConfiguration
            (this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IRoleReport,RoleReport>();
            services.AddScoped<IRoleService,RoleService>();

            services.AddScoped<IUserReport, UserReport>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IProvinceReport, ProvinceReport>();
            services.AddScoped<IProvinceService, ProvinceService>();

            services.AddScoped<ICityReport, CityReport>();
            services.AddScoped<ICityService, CityService>();

            services.AddScoped<IUserAddressReport, UserAddressReport>();
            services.AddScoped<IUserAddressService, UserAddressService>();


            services.AddScoped<ICategoryReport, CategoryReport>();
            services.AddScoped<ICategoryService, CategoryService>();      
            
            
            services.AddScoped<ICategoryUserReport, CategoryUserReport>();
            services.AddScoped<ICategoryUserService, CategoryUserService>();





            return services;
        }
    }
}
