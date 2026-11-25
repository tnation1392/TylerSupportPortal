using System;
using System.Collections.Generic;
using System.Text;

namespace TylerSupportPortal.Tests.Shared;

public abstract class BaseTest
{
    [OneTimeSetUp]
    public void GlobalSetup()
    {
        Console.WriteLine(
            $"Starting {GetType().Name}");
    }

    [OneTimeTearDown]
    public void GlobalCleanup()
    {
        Console.WriteLine(
            $"Finished {GetType().Name}");
    }
}
