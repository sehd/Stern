using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SigmaSharp.Stern.ModuleFramework;
using SigmaSharp.Stern.Web.Models.Authentication;
using SigmaSharp.Stern.Web.Modules;
using SigmaSharp.Stern.Web.Persistance;
using System.Text;

namespace SigmaSharp.Stern.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CoreDbContext>(options =>
            {
                //TODO Temp
                options.UseSqlite("SQLite.db3");
            });
            ConfigureAuthentication(services);

            var moduleAssemblies = services.LoadModules();
            var mvcBuilder = services.AddMvc(option => option.EnableEndpointRouting = false);
            foreach (var assembly in moduleAssemblies)
            {
                mvcBuilder.AddApplicationPart(assembly);
            }
            mvcBuilder.AddControllersAsServices();

            services.AddTransient<ISettingProvider, ModulesSettingProvider>();
        }

        private static void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<CoreDbContext>()
                            .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "http://dotnetdetail.net", //TODO
                    ValidIssuer = "http://dotnetdetail.net", //TODO
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecureKey")) //TODO
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.Map("/admin", admin =>
            {
                admin.UseSpa(spa =>
                {
                    spa.Options.SourcePath = "Admin";
                    if (env.IsDevelopment())
                    {
                        spa.UseAngularCliServer("start");
                    }
                });
            });

            _ = new DataSeeder().InitializeDatabaseAsync(app.ApplicationServices);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
