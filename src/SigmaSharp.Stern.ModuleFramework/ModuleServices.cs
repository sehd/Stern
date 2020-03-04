using System;

namespace SigmaSharp.Stern.ModuleFramework
{
    [Flags]
    public enum ModuleServices
    {
        None = 0,
        ApiController = 1,
        BackgroundService = 2,
        HttpClient = 4,
        SignalR = 8
    }
}
