namespace Software.Logger
{
    internal interface ILogger
    {
        void Log(LogLevels logLevel, string message);
    }
}