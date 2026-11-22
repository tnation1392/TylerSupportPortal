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

    public static IEnumerable<TestCaseData> CustomerCreationTestCases()
    {
        yield return new TestCaseData(
            "Acme Corp",
            true,
            "Acme Corp");

        yield return new TestCaseData(
            "Tyler Technologies",
            true,
            "Tyler Technologies");

        yield return new TestCaseData(
            "Contoso",
            true,
            "Contoso");
    }

    [TestCaseSource(nameof(CustomerCreationTestCases))]
    public void CustomerCreationBehavior(
    string customerName,
    bool expectedActive,
    string expectedName)
    {
        var customer =
            _service.CreateCustomer(customerName);

        _createdCustomers.Add(customer);

        Assert.That(customer.Active,
            Is.EqualTo(expectedActive));

        Assert.That(customer.Name,
            Is.EqualTo(expectedName));

        Assert.That(customer.Id,
            Is.GreaterThan(0));
    }

    [Test]
    public void ImportedCustomerCountShouldBeValid(
    [Range(1, 100, 10)] int customerCount)
    {
        Assert.That(customerCount,
            Is.GreaterThan(0));
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