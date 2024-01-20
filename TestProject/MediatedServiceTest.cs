using NUnit.Framework.Internal;

using Software.Service;

namespace TestProject;

[TestFixture]
public class MediatedServiceTest
{
    private MediatedService _service;

    #region Test Life-Cycle
    [SetUp]
    public void Setup() => _service = new MediatedService(null);

    [TearDown]
    public void Teardown() => _service = null;
    #endregion

    [Test]
    public void GivenDoAnythingWhenRunThenShouldNotThrowException() => _service.DoAnything();

    [Test]
    [Description("Taumatawhakatangi­hangakoauauotamatea­turipukakapikimaunga­horonukupokaiwhen­uakitanatahu like method name")]
    public void GivenDoAnythingSendErrorWhenRunThenShouldNotThrowException() => _service.DoAnythingSendError();
}
