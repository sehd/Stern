﻿using Microsoft.Extensions.DependencyInjection;
using SigmaSharp.Stern.ModuleFramework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SigmaSharp.Stern.Web
{
    static class ModuleManagementExtentions
    {
        public static IEnumerable<Assembly> LoadModules(
            this IServiceCollection services)
        {
            var allAssemblies = new List<Assembly>();
            string path = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Modules");

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
            {
                var assembly = Assembly.LoadFile(dll);
                var modulesInAssembly = assembly.GetExportedTypes()
                    .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
                if (modulesInAssembly.Any())
                {
                    foreach (var module in modulesInAssembly)
                    {
                        services.AddSingleton(module);
                    }
                    allAssemblies.Add(assembly);
                }
            }

            return allAssemblies;
        }
    }
}
