﻿using NUnit.Framework.Internal;

using Software.Service;

namespace TestProject;

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
    public void GivenDoServiceWhenFinishedThenNoException()
    {
        _service.DoService();
    }
}