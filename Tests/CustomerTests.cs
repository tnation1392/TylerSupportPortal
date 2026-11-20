using System;
using System.Collections.Generic;
using System.Text;

using TylerSupportPortal.Tests.Services;

namespace TylerSupportPortal.Tests.Tests;

[TestFixture]
public class CustomerTests
{
    private CustomerService _service;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
    }

    [Test]
    public void CustomerIsCreatedAsActive()
    {
        var customer = _service.CreateCustomer("Acme Corp");

        Assert.That(customer.Active, Is.True);
    }
}


