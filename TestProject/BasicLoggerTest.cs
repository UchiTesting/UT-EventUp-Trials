using NUnit.Framework.Internal;

using Software.Logger;

namespace TestProject;

[TestFixture]
public class BasicLoggerTests
{
    BasicLogger _logger;

    #region Test Life-Cycle
    [SetUp]
    public void Setup() => _logger = new BasicLogger();

    [TearDown]
    public void Teardown() => _logger = null;
    #endregion

    [Test]
    [Description("Just logs a few messages")]
    public void Given3LoggingsWhenFinishedThen3Outputs()
    {
        _logger.Log(LogLevels.Info, "This is cool info");
        _logger.Log(LogLevels.Warn, "This is friendly warning");
        _logger.Log(LogLevels.Error, "This is bad error");
    }
}
