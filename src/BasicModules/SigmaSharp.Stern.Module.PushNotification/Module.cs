using SigmaSharp.Stern.ModuleFramework;
using System.Collections.Generic;

namespace SigmaSharp.Stern.Module.PushNotification
{
    public class Module : IModule
    {
        public string Name => "PushNotification";

        public string Title => "Push Notification";

        public string Description => "Does PN using FireBase Messaging Service";

        public IEnumerable<ICommand> Commands => throw new System.NotImplementedException();

        public IEnumerable<IQuery> Queries => throw new System.NotImplementedException();

        public IEnumerable<ISetting> Settings => throw new System.NotImplementedException();
    }
}
