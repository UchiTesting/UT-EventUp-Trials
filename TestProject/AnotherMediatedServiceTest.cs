using NUnit.Framework.Internal;

using Software.Service;

namespace TestProject;

[TestFixture]
public class AnotherMediatedServiceTest
{
    private AnotherMediatedService _service;

    #region Test Life-Cycle
    [SetUp]
    public void Setup() => _service = new AnotherMediatedService(null);

    [TearDown]
    public void Teardown() => _service = null;
    #endregion

    [Test]
    public void GivenDoAnythingAnotherWayWhenRunThenShouldNotThrowException() =>
        // Cool but where is the rum gone ?
        // I mean the output when testing ?
        _service.DoAnythingAnotherWay("TEST");
}
