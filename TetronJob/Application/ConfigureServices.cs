
using Application.Reports.Article;
using Application.Reports.ArticleCategory;
using Application.Reports.Category;
using Application.Reports.CategoryUser;
using Application.Reports.City;
using Application.Reports.Contact;
using Application.Reports.Introduction;
using Application.Reports.Placement;
using Application.Reports.Province;
using Application.Reports.Recruitment;
using Application.Reports.Role;
using Application.Reports.Setting;
using Application.Reports.Skill;
using Application.Reports.SkillIntroduction;
using Application.Reports.Slider;
using Application.Reports.User;
using Application.Reports.UserAddress;
using Application.Services.Article;
using Application.Services.ArticleCategory;
using Application.Services.Category;
using Application.Services.CategoryUser;
using Application.Services.City;
using Application.Services.Contact;
using Application.Services.Introduction;
using Application.Services.Picture;
using Application.Services.Placement;
using Application.Services.Province;
using Application.Services.Recruitment;
using Application.Services.Role;
using Application.Services.Setting;
using Application.Services.Skill;
using Application.Services.SkillIntroduction;
using Application.Services.Slider;
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



 
            services.AddScoped<ISkillReport, SkillReport>();
            services.AddScoped<ISkillService, SkillService>();

 
            services.AddScoped<IIntroductionReport, IntroductionReport>();
            services.AddScoped<IIntroductionService, IntroductionService>();

            services.AddScoped<IRecruitmentService, RecruitmentService>();
            services.AddScoped<IRecruitmentReport, RecruitmentReport>();

            services.AddScoped<IPictureService, PictureService>();


            services.AddScoped<IPlacementService, PlacementService>();
            services.AddScoped<IPlacementReport, PlacementReport>();

            services.AddScoped<ISkillIntroductionReport, SkillIntroductionReport>();
            services.AddScoped<ISkillIntroductionService, SkillIntroductionService>();

            services.AddScoped<IArticleCategoryReport, ArticleCategoryReport>();
            services.AddScoped<IArticleCategoryService, ArticleCategoryService>();

            services.AddScoped<IArticleReport, ArticleReport>();
            services.AddScoped<IArticleService, ArticleService>();

            services.AddScoped<ISliderReport, SliderReport>();
            services.AddScoped<ISliderService, SliderService>();




            services.AddScoped<ISettingReport, SettingReport>();
            services.AddScoped<ISettingService, SettingService>();



            services.AddScoped<IContactReport, ContactReport>();
            services.AddScoped<IContactService, ContactService>();





            return services;
        }
    }
}
