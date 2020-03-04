using SigmaSharp.Stern.ModuleFramework;
using System.Collections.Generic;

namespace SigmaSharp.Stern.Module.CronService
{
    public class Module : IModule
    {
        public string Name => "cron-service";

        public string Title => "Cron Service";

        public string Description => "Basically a time based service that can do tasks in " +
            "predefined times or set intervals.";

        public IEnumerable<ISetting> Settings => throw new System.NotImplementedException();

        public ModuleServices ModuleServices => ModuleServices.None;
    }
}
