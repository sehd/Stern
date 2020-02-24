using SigmaSharp.Stern.ModuleFramework;
using System.Collections.Generic;

namespace SigmaSharp.Stern.Module.CronService
{
    public class Module : IModule
    {
        public string Name => "CronService";

        public string Title => "Cron Service";

        public string Description => "Basically a time based service that can do tasks in " +
            "predefined times or set intervals.";

        public IEnumerable<ICommand> Commands => throw new System.NotImplementedException();

        public IEnumerable<IQuery> Queries => throw new System.NotImplementedException();

        public IEnumerable<ISetting> Settings => throw new System.NotImplementedException();
    }
}
