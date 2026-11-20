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
    private AuthenticationService _service;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _service = new AuthenticationService();
    }

    [Test]
    public void ValidUserCanLogin()
    {

        var user = new User
        {
            Username = "tnason",
            Password = "Password123",
            IsLocked = false
        };

        bool result = _service.Login(user);

        Assert.That(result, Is.True);
    }

    [Test]
    public void LockedUserCannotLogin()
    {

        var user = new User
        {
            Username = "tnason",
            Password = "Password123",
            IsLocked = true
        };

        bool result = _service.Login(user);

        Assert.That(result, Is.False);
    }

    [OneTimeTearDown]
    public void OneTimeCleanup()
    {
        _service = null;
    }
}

