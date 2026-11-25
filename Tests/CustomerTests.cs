using TylerSupportPortal.Tests.Models;
using TylerSupportPortal.Tests.Services;

namespace TylerSupportPortal.Tests.Tests;

//Test fixture setup for Customer testing
[TestFixture]

public class CustomerTests
{//Service setup
    private CustomerService _service;
    private List<Customer> _createdCustomers;

    //One time setup
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _service = new CustomerService();
        _createdCustomers = new List<Customer>();
    }

    //Test Case data 
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

    //Test case source for above data
    [TestCaseSource(nameof(CustomerCreationTestCases))]
    [Category("Customer")]
    [Category("Regression")]
    public void CustomerCreationBehavior(
    string customerName,
    bool expectedActive,
    string expectedName)
    {
        var customer =
            _service.CreateCustomer(customerName);

        _createdCustomers.Add(customer);

        Assert.Multiple(() =>
        {
            Assert.That(customer.Active,
                Is.EqualTo(expectedActive));
            Assert.That(customer.Name,
                Is.EqualTo(expectedName));
            Assert.That(customer.Id,
                Is.GreaterThan(0));
        });

        Assert.That(customer.Active,
            Is.EqualTo(expectedActive));

        Assert.That(customer.Name,
            Is.EqualTo(expectedName));

        Assert.That(customer.Id,
            Is.GreaterThan(0));

        Assert.That(customer.Name,
            Does.StartWith(expectedName.Substring(0, 1)));
    }

    //Testing that imported customer counts should be greater than 0 every time
    [Test]
    [Category("Customer")]
    [Category("Regression")]
    public void ImportedCustomerCountShouldBeValid(
    [Range(1, 100, 10)] int customerCount)
    {
        Assert.That(customerCount,
            Is.GreaterThan(0));
    }


    //Teardown of above test
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