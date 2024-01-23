using System.Globalization;
using FluentValidation.AspNetCore;
using Framework.Common;
using Framework.Common.Behaviors;
using Framework.Factories.ArticleCategory;
using Framework.Factories.Category;
using Framework.Factories.City;
using Framework.Factories.Identity.Role;
using Framework.Factories.Identity.User;
using Framework.Factories.Introduction;
using Framework.Factories.Placement;
using Framework.Factories.Province;
using Framework.Factories.Recruitment;
using Framework.Factories.Skill;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Framework
{
    [Obsolete]
    public static class ConfigureServices
    {
        public static IServiceCollection FrameworkConfiguration
            (this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(FrameworkReference).Assembly));


            // Add Fluent Validation services.



            services.AddFluentValidationAutoValidation();
            services.AddFluentValidation(fv =>
            {
                fv.ValidatorOptions.LanguageManager.Enabled = true;
                fv.ValidatorOptions.LanguageManager.Culture = new CultureInfo("fa");
                fv.RegisterValidatorsFromAssemblyContaining<BaseValidator<object>>();
            });

            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidateCommandBehavior<,>));


            services.AddScoped<IArticleCategoryFactory, ArticleCategoryFactory>();
            services.AddScoped<ICategoryFactory, CategoryFactory>();
            services.AddScoped<IRoleFactory, RoleFactory>();
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<IProvincesFactory, ProvincesFactory>();
            services.AddScoped<ICityFactory, CityFactory>();
            services.AddScoped<ISkillFactory, SkillFactory>();
            services.AddScoped<IRecruitmentFactory, RecruitmentFactory>();
            services.AddScoped<IPlacementFactory, PlacementFactory>();
            services.AddScoped<IIntroductionFactory, IntroductionFactory>();
            return services;
        }
    }
}
