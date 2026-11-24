using System;
using System.Collections.Generic;
using System.Text;

using TylerSupportPortal.Tests.Models;

namespace TylerSupportPortal.Tests.Services;

//A class used for customer retrieval

public class CustomerService
{
    public Customer CreateCustomer(string name)
    {
        return new Customer
        {
            Id = 1,
            Name = name,
            Active = true
        };
    }
}
