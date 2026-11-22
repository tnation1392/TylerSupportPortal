using System;
using System.Collections.Generic;
using System.Text;

namespace TylerSupportPortal.Tests.Models;

//Creates a ticket object with an Id, Title, and Status.
public class Ticket
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Status { get; set; }
}
