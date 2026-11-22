using System;
using System.Collections.Generic;
using System.Text;

namespace TylerSupportPortal.Tests.Models;

//Creates a customer object with an Id, Name, and Active status.
public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool Active { get; set; }
}