using TylerSupportPortal.Tests.Services;

[TestFixture]
public class TicketTests
{
    private TicketService _service;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _service = new TicketService();
    }

    [Test]
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
}