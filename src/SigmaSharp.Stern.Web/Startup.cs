using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SigmaSharp.Stern.ModuleFramework;
using System.Linq;

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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
