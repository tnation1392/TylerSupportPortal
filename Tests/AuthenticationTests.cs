using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using TylerSupportPortal.Tests.Models;
using TylerSupportPortal.Tests.Services;

namespace TylerSupportPortal.Tests.Tests;

[TestFixture]
public class AuthenticationTests
{
    [Test]
    public void ValidUserCanLogin()
    {
        var service = new AuthenticationService();

        var user = new User
        {
            Username = "tnason",
            Password = "Password123",
            IsLocked = false
        };

        bool result = service.Login(user);

        Assert.That(result, Is.True);
    }

    [Test]
    public void LockedUserCannotLogin()
    {
        var service = new AuthenticationService();

        var user = new User
        {
            Username = "tnason",
            Password = "Password123",
            IsLocked = true
        };

        bool result = service.Login(user);

        Assert.That(result, Is.False);
    }
}
