using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.OrderManagement.Infrustructure.Identity;
using MLA.OrderManagement.Infrustructure.Persistance;
using MLA.OrderManagement.Infrustructure.Services;
using System;
using System.Text;

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
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            //services.AddTransient<ITokenService, TokenService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            //var key = Encoding.ASCII.GetBytes(configuration.GetSection("Jwt")["key"].ToString());

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddIdentityServerJwt(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ValidateLifetime = true,
            //        ValidIssuer = configuration.GetSection("Jwt")["Issuer"].ToString(),
            //        ValidAudience = configuration.GetSection("Jwt")["Audience"].ToString(),
            //    };
            //    //x.Events = new JwtBearerEvents
            //    //{
            //    // OnTokenValidated = context =>
            //    // {
            //    // var jwt = (context.SecurityToken as JwtSecurityToken)?.ToString();
            //    // // get your JWT token here if you need to decode it e.g on https://jwt.io
            //    // // And you can re-add role claim if it has different name in token compared to what you want to use in your ClaimIdentity:
            //    // AddRoleClaims(context.Principal);
            //    // return Task.CompletedTask;
            //    // }
            //    //};
            //});


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
