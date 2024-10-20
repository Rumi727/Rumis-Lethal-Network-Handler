namespace Rumi.LCNetworks
{
    static class Debug
    {
        public static void Log(object data) => LCNHPlugin.logger?.LogInfo(data);
        public static void LogWarning(object data) => LCNHPlugin.logger?.LogWarning(data);
        public static void LogError(object data) => LCNHPlugin.logger?.LogError(data);
    }
}
