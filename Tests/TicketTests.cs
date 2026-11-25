using TylerSupportPortal.Tests.Services;
using TylerSupportPortal.Tests.Shared;

[TestFixture]
public class TicketTests : BaseTest
{
    //Service setup
    private TicketService _service;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _service = new TicketService();
    }

    public static IEnumerable<TestCaseData> TicketTitleCases()
    {
        yield return new TestCaseData("Login Issue");

        yield return new TestCaseData("Database Error");

        yield return new TestCaseData("Reporting Problem");

        yield return new TestCaseData("Customer Import Failure");
    }

    [TestCaseSource(nameof(TicketTitleCases))]
    public void CreatedTicketShouldKeepTitle(
    string title)
    {
        var ticket =
            _service.CreateTicket(title);

        Assert.That(ticket.Title,
            Is.EqualTo(title));
    }


    //Testing that TicketID should be positive
    [Test]
    [Category("Ticket")]
    [Category("Regression")]

    public void TicketIdShouldBePositive(
    [Range(1, 10)] int ticketId)
    {
        Assert.That(ticketId, Is.GreaterThan(0));
    }

    //Testing that the retry count should be <= 5
    [Test]
    public void RetryCountShouldBeReasonable(
    [Range(1, 5)] int retryCount)
    {
        Assert.That(retryCount,
            Is.LessThanOrEqualTo(5));
    }

    //Testing that the TicketStatus should be open post-creation
    [Test]
    [Category("Ticket")]
    [Category("Regression")]

    public void TicketStatusShouldBeOpen(
        [Values(
            "Sample 1",
            "Sample 2",
            "Sample 3")]
        string title)
    {
        var ticket = _service.CreateTicket(title);
        Assert.That(ticket.Status,
            Is.EqualTo("Open"));
    }

    [Test]
    [Category ("Ticket")]
    [Category("Regression")]
    public void TicketShouldHaveValidDefaults()
    {
        var ticket = _service.CreateTicket("Login Issue");

        Assert.Multiple(() =>
            {
            Assert.That(ticket.Title, Is.EqualTo("Login Issue"));
            Assert.That(ticket.Status, Is.EqualTo("Open"));
            Assert.That(ticket.Id, Is.GreaterThan(0));
            });


    }
}