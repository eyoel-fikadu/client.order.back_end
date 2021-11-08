using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Identity
{
    public static class IdentityDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IIdentityService, IdentityService>();

            //services.AddAuthentication()
            //    .AddIdentityServerJwt();

            //services.AddAuthorization(options =>
            //{
            //    //options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            //});

            services.AddSingleton<ISqlConnectionFactory>(x => new SqlConnectionFactory(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IDapperContext, DapperContext>();
            return services;
        }

    }
}
