using System;
using System.Collections.Generic;
using System.Text;

using TylerSupportPortal.Tests.Models;

namespace TylerSupportPortal.Tests.Services;

public class AuthenticationService
{
    public bool Login(User user)
    {
        return !user.IsLocked &&
               user.Password == "Password123";
    }
}
