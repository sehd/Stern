using SigmaSharp.Stern.ModuleFramework;
using System.Collections.Generic;

namespace SigmaSharp.Stern.Module.PushNotification
{
    public class Module : IModule
    {
        public string Name => "push-notification";

        public string Title => "Push Notification";

        public string Description => "Does PN using FireBase Messaging Service";

        public IEnumerable<ISetting> Settings => throw new System.NotImplementedException();

        public ModuleServices ModuleServices => ModuleServices.None;
    }
}
