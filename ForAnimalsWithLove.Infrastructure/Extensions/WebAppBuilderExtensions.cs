using Microsoft.Extensions.DependencyInjection;

using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.Data.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using ForAnimalsWithLove.Data.Models;

namespace ForAnimalsWithLove.Infrastructure.Extensions
{
    public static class WebAppBuilderExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IAdminService, AdminService>();

        }

        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app, string email)
        { 
            using var serviceScope = app.ApplicationServices.CreateScope();
            var servicePrvider = serviceScope.ServiceProvider;

            var userManager = servicePrvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = servicePrvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync("Administrator"))
                {
                    return;
                }

                var role = new IdentityRole<Guid>("Administrator");
                await roleManager.CreateAsync(role);

                var adminUser = await userManager.FindByEmailAsync(email);
                await userManager.AddToRoleAsync(adminUser, "Administrator");
            }).GetAwaiter()
              .GetResult();

            return app;
        }
    }
}
