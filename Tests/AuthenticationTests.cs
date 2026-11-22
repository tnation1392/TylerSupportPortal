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
    public static IEnumerable<TestCaseData> LoginTestCases()
    {
        yield return new TestCaseData(
            new User
            {
                Username = "tnason",
                Password = "Password123",
                IsLocked = false
            },
            true);

        yield return new TestCaseData(
            new User
            {
                Username = "tnason",
                Password = "Password123",
                IsLocked = true
            },
            false);

        yield return new TestCaseData(
            new User
            {
                Username = "lockeduser",
                Password = "Password123",
                IsLocked = true
            },
            false);

        yield return new TestCaseData(
            new User
            {
                Username = "badpassword",
                Password = "WrongPassword",
                IsLocked = false
            },
            false);
    }

    [TestCaseSource(nameof(LoginTestCases))]
    public void UserLoginBehavior
        (
        User user, 
        bool expectedResult
        )
    {
        var service = new AuthenticationService();
        bool result = service.Login(user);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    private AuthenticationService _service;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _service = new AuthenticationService();
    }

    [OneTimeTearDown]
    public void OneTimeCleanup()
    {
        _service = null;
    }
}

