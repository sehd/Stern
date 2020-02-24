using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SigmaSharp.Stern.ModuleFramework;

namespace SigmaSharp.Stern.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISettingProvider, ModulesSettingProvider>();

            var moduleAssemblies = services.LoadModules();
            var mvcBuilder = services.AddMvc(option => option.EnableEndpointRouting = false);
            foreach (var assembly in moduleAssemblies)
            {
                mvcBuilder.AddApplicationPart(assembly);
            }
            mvcBuilder.AddControllersAsServices();

            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "Admin/dist";
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSpa(configuration =>
            {
                configuration.Options.SourcePath = "Admin";
                //if (env.IsDevelopment())
                //{
                //    configuration.UseAngularCliServer("serve");
                //}
            });

            app.UseMvc();
        }
    }
}
