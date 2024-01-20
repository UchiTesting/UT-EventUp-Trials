using System.Collections.Generic;
using System.Linq;

namespace Software.Logger
{
    /// <summary>
    /// Allows to convert easily and performance-wise from string to LogLevels enum
    /// </summary>
    public static class LogLevelsInfo
    {

        private static Dictionary<LogLevels, string> LogLevelsDictionary = new Dictionary<LogLevels, string> {
            { LogLevels.Info, LogLevels.Info.ToString() },
            { LogLevels.Warn, LogLevels.Warn.ToString() },
            { LogLevels.Error, LogLevels.Error.ToString()}
        };

        public static LogLevels GetLogLevelEnumValueFromString(string value)
        {
            bool hasValue = LogLevelsDictionary.Values
                .Select(v => v.ToUpperInvariant())
                .Contains(value.ToUpperInvariant());

             return (hasValue)
                ? LogLevelsDictionary
                .Single(kvp => kvp.Value.ToUpperInvariant().Equals(value.ToUpperInvariant()))
                .Key
                : throw new System.Exception($"I KEEL YOU! Log level {value} does NOT exist.");
        }
    }
}