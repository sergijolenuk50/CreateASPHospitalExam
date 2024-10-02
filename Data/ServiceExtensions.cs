using Data.Data;
using Data.Entities;
using Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication3.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<HospitalDbContext>(options => options.UseSqlServer(connectionString));

        }
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<HospitalDbContext>();
        }
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

    }
}
