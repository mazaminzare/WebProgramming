using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Data.Repositories;
using CleanArch.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArch.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            // Application Layer
            services.AddScoped<ICourseService,CourseService>();
            services.AddScoped<IUserService,UserService>();


            // Infra Data Layer
            services.AddScoped<ICourseRepository,CourseRepository>();
            services.AddScoped<IUserRepository,UserRepository>();

            return services;
        }
    }
}
