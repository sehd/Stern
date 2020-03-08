using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SigmaSharp.Stern.ModuleFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SigmaSharp.Stern.Web.Modules
{
    static class ModuleManagementExtentions
    {
        public static IEnumerable<Assembly> AddModules(this IServiceCollection services)
        {
            var allAssemblies = new List<Assembly>();
            var allModules = new ModuleCollection();
            string path = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Modules");

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
            {
                var assemblymodule = LoadModule(dll);
                if (assemblymodule.HasValue)
                {
                    var (assembly, module) = assemblymodule.Value;
                    allModules.Add(module);
                    allAssemblies.Add(assembly);
                }
            }

            services.AddSingleton<IModuleCollection>(allModules);
            return allAssemblies;
        }

        public static (Assembly, IModule)? LoadModule(string dllPath)
        {
            var assembly = Assembly.LoadFile(dllPath);
            var moduleInAssembly = assembly.GetExportedTypes()
                .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .FirstOrDefault();
            if (moduleInAssembly != default)
            {
                var module = moduleInAssembly.GetConstructor(Array.Empty<Type>()).Invoke(null) as IModule;
                if (module.ModuleServices.HasFlag(ModuleServices.ApiController))
                    if (!CheckRoutings(module, assembly))
                        throw new InvalidOperationException($"Error in module {module.Name}. Routing doesn't match the required pattern");
                return (assembly, module);
            }
            return null;
        }

        private static bool CheckRoutings(IModule module, Assembly assembly)
        {
            var controllers = assembly.GetTypes()
                .Where(x => typeof(Controller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
            foreach (var controller in controllers)
            {
                var routes = controller.GetCustomAttributes<RouteAttribute>(true);
                foreach (var route in routes)
                {
                    if (!route.Template.StartsWith(module.Name))
                        return false;
                }
            }
            return true;
        }
    }
}
