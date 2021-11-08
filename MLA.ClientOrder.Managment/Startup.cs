using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MLA.ClientOrder.API.Filters;
using MLA.ClientOrder.API.Services;
using MLA.ClientOrder.Application;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.OrderManagement.Infrustructure;
using MLA.OrderManagement.Infrustructure.Persistance;

namespace MLA.ClientOrder.Managment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();

            #region cors

            services.AddHealthChecks();

            services.AddCors(o => o.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                }));

            services.Configure<IISOptions>(options =>
                {
                    options.AutomaticAuthentication = false;
                });

            #endregion

            services.AddMvc(options =>
              options.Filters.Add<ApiExceptionMiddleware>());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MLA.ClientOrder.Managment", Version = "v1" });
                c.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MLA.ClientOrder.Managment v1"));

            if (env.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MLA.ClientOrder.Managment v1"));

            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseHealthChecks("/health");

            //app.UseSwaggerUi3(settings =>
            //{
            //    settings.Path = "/api";
            //    settings.DocumentPath = "/api/specification.json";
            //});
            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
