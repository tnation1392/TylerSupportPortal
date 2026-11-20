using System;
using System.Collections.Generic;
using System.Text;

using TylerSupportPortal.Tests.Services;

namespace TylerSupportPortal.Tests.Tests;

[TestFixture]
public class CustomerTests
{
    [Test]
    public void CustomerIsCreatedAsActive()
    {
        var service = new CustomerService();

        var customer = service.CreateCustomer("Acme Corp");

        Assert.That(customer.Active, Is.True);
    }
}

