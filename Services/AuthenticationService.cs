using System;
using System.Collections.Generic;
using System.Text;

using TylerSupportPortal.Tests.Models;

namespace TylerSupportPortal.Tests.Services;

//A class used for login testing
public class AuthenticationService
{
    public bool Login(User user)
    {
        return !user.IsLocked &&
               user.Password == "Password123";
    }
}
