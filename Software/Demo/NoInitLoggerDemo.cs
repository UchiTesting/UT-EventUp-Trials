using Software.Logger;

namespace Software.Demo
{
    /// <summary>
    /// Some class without initiated logger
    /// aiming at reproducing a problem I am facing.
    /// I am in a situation where the _logger cannot be initialized
    /// </summary>
    public class NoInitLoggerDemo
    {
        BasicLogger _logger; // purposely not initiating logger.


        /// <summary>
        /// Throws System.NullReferenceException on purpose
        /// </summary>
        public void Showcase()
        {
            if (_logger != null)
                _logger.Log(LogLevels.Info, "Will it blend?");
        }

    }
}
