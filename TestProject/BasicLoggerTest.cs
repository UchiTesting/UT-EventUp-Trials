using NUnit.Framework.Internal;

using Software;
using Software.Logger;

namespace TestProject;

[TestFixture]
public class Tests
{
    BasicLogger _logger;

    #region Test Life-Cycle
    [SetUp]
    public void Setup()
    {
        _logger = new BasicLogger();
    }

    [TearDown]
    public void Teardown()
    {
        _logger = null;
    }
    #endregion

    [Test]
    [Description("")]
    public void GivenWhenThen1()
    {
        _logger.Log(LogLevels.Info, "This is cool info");
        _logger.Log(LogLevels.Warn, "This is friendly warning");
        _logger.Log(LogLevels.Error, "This is bad error");
        //Assert.Fail();
    }

    [Test]
    [Description("")]
    public void GivenWhenThen2()
    {
        Assert.Pass();
    }
}

[TestFixture]
public class TestFrameworkTest
{
    [Test]
    [Description("This should fail no matter what")]
    public void GivenAssertFailThenFail()
    {
        Assert.Fail();
    }

    [Test]
    [Description("This should pass no matter what")]
    public void GivenAssertPassThenPass()
    {
        Assert.Pass();
    }
}

[TestFixture]
public class ServiceTest
{
    private Service _service;

    #region Test Life-Cycle
    [SetUp]
    public void Setup()
    {
        _service = new Service();
    }

    [TearDown]
    public void Teardown()
    {
        _service = null;
    }
    #endregion

    [Test]
    [Description("This should fail no matter what")]
    public void GivenWhenThen1()
    {
        _service.DoService();
        //Assert).Fail();
    }

    [Test]
    [Description("This should pass no matter what")]
    public void GivenWhenThen2()
    {
        Assert.Pass();
    }
}