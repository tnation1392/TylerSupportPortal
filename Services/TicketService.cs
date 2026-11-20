using System;
using System.Collections.Generic;
using System.Text;

using TylerSupportPortal.Tests.Models;

namespace TylerSupportPortal.Tests.Services;

public class TicketService
{
    public Ticket CreateTicket(string title)
    {
        return new Ticket
        {
            Id = 100,
            Title = title,
            Status = "Open"
        };
    }
}
