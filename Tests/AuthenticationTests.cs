using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using TylerSupportPortal.Tests.Models;
using TylerSupportPortal.Tests.Services;

namespace TylerSupportPortal.Tests.Tests;

//A test fixture containing multiple User setups used for testing below
[TestFixture]
public class AuthenticationTests
{

    //One time setup for Authentication tests
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _service = new AuthenticationService();
    }
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

    //TestCaseSource used to act on the above Fixture
    [TestCaseSource(nameof(LoginTestCases))]
    [Category("Authentication")]
    [Category("Smoke")]
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

    
    //TearDown
    [OneTimeTearDown]
    public void OneTimeCleanup()
    {
        _service = null;
    }
}

