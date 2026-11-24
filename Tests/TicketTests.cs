using TylerSupportPortal.Tests.Services;

[TestFixture]
public class TicketTests
{
    //Service setup
    private TicketService _service;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _service = new TicketService();
    }

    //Testing that created tickets keep their title
    [Test]
    [Category("Ticket")]
    [Category("Regression")]
    public void CreatedTicketShouldKeepTitle(
        [Values(
            "Login Issue",
            "Database Error",
            "Reporting Problem")]
        string title)
    {
        var ticket = _service.CreateTicket(title);

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
}