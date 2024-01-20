namespace Software.Logger
{
    public interface ILogger
    {
        void Log(LogLevels logLevel, string message);
    }
}