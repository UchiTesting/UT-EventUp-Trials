using Software.Logger;

namespace Software.Demo
{
    class InitLoggerDemo
    {
        public void Showcase()
        {
            BasicLogger _logger = new BasicLogger();

            _logger.Log(LogLevels.Info, "This is cool info");
            _logger.Log(LogLevels.Warn, "This is friendly warning");
            _logger.Log(LogLevels.Error, "This is bad error");
        }
    }
}
