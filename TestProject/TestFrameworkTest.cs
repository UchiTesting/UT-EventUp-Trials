using NUnit.Framework.Internal;

namespace TestProject;

[Explicit]
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
