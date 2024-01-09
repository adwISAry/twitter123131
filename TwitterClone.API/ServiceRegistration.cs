using Microsoft.AspNetCore.Identity;
using TwitterClone.Core.Entities;
using TwitterClone.DatabaseAccessLayer.Contexts;

namespace TwitterClone.API
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddUserIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<TwitterCloneDbContext>();

            return services;
        }
        //public static IServiceCollection AddAuth(this IServiceCollection services) 
        //{

        //}
    }
}
