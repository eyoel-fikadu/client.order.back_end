using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.OrderManagement.Infrustructure.Identity;
using MLA.OrderManagement.Infrustructure.Persistance;
using MLA.OrderManagement.Infrustructure.Services;
using System;

namespace MLA.OrderManagement.Infrustructure
{
    public static class DependencyInjectionExtenstion
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                //services.AddDbContext<ApplicationDbContext>(options =>
                //    options.UseInMemoryDatabase("CleanArchitectureDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services
                .AddDefaultIdentity<ApplicationUser>(options => 
                {
                    //password settings
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 6;
                    //options.Password.RequiredUniqueChars = 2;

                    // Lockout settings.
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;
                    options.User.RequireUniqueEmail = true;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();
 
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            });

            services.AddSingleton<ISqlConnectionFactory>(x => new SqlConnectionFactory(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IDapperContext, DapperContext>();
            return services;
        }

    }
}
