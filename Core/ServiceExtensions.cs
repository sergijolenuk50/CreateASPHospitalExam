using Core.Interfaces;
using Core.MapperProfiles;
using Core.Services;
using Data.Data;
using Data.Entities;
using Data.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication3.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDoctorsService, DoctorsService>();
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<IJwtService, JwtService>();

        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppProfile));
        }

        public static void AddFluentValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }

    }
}
