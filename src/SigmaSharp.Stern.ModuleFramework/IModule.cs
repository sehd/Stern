using System.Collections.Generic;

namespace SigmaSharp.Stern.ModuleFramework
{
    public interface IModule
    {
        string Name { get; }
        string Title { get; }
        string Description { get; }
        IEnumerable<ISetting> Settings { get; }
        ModuleServices ModuleServices { get; }
    }
}
