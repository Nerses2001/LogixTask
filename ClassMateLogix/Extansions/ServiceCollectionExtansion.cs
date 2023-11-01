using AutoMapper;
using ClassMateLogix.Filters;
using DataLayer;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Model.Mapper;

namespace ClassMateLogix.Extansions
{
    public static class ServiceCollectionExtansion
    {
        public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(

                mc =>
                {
         //           mc.AddProfile(new UserProfile());
                    mc.AddProfile(new ApplicationUserProfile());
                    mc.AddProfile(new CourseProfile());
                    mc.AddProfile(new UserCourseProfile());

                }
            );

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
            return services;
        }
        public static IServiceCollection AddIdentityServer(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>
                (c =>
                {
                    c.Password.RequireDigit = true;
                    c.Password.RequireLowercase = true;
                    c.Password.RequiredLength = 8;
                    c.Password.RequireNonAlphanumeric = true;
                    c.Password.RequireUppercase = true;
                })
                .AddEntityFrameworkStores<DataBaseContext>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddDefaultTokenProviders();

            return services;

        }
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClassMateLogixAPI", Description = "Description for project API", Version = "v1" });
                c.OperationFilter<AddAuthHeaderOperationFilter>();
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });


                c.DocumentFilter<SwaggerAddEnumDescriptionsFilter>();
            });

            return services;
        }
    }
}
