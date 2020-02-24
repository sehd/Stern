using SigmaSharp.Stern.ModuleFramework;
using System.Collections.Generic;

namespace SigmaSharp.Stern.Module.UserStorage
{
    public class Module : IModule
    {
        public string Name => "UserStorage";

        public string Title => "User Storage";

        public string Description => "A storage that keeps small data for each user. " +
            "It can be used (i.e. read or update) only by the user";

        public IEnumerable<ISetting> Settings { get; }

        
    }
}
