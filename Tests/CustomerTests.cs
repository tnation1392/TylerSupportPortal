using TylerSupportPortal.Tests.Models;
using TylerSupportPortal.Tests.Services;

namespace TylerSupportPortal.Tests.Tests;

[TestFixture]
public class CustomerTests
{
    private CustomerService _service;
    private List<Customer> _createdCustomers;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _service = new CustomerService();
        _createdCustomers = new List<Customer>();
    }

    [Test]
    public void CustomerIsCreatedAsActive()
    {
        var customer = _service.CreateCustomer("Acme Corp");

        _createdCustomers.Add(customer);

        Assert.That(customer.Active, Is.True);
    }

    [TearDown]
    public void CleanupTestData()
    {
        _createdCustomers.Clear();
    }

    [OneTimeTearDown]
    public void OneTimeCleanup()
    {
        Console.WriteLine("CustomerTests complete.");

        _service = null;
        _createdCustomers = null;
    }
}