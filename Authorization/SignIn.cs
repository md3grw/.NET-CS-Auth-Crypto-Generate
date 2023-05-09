//Login
using SilevenText.Entity;
using System;

namespace SilevenText.Authorization
{
    internal class SignIn
    {
        public bool Login(User user)
        {
            Validator validator= new Validator();
            if (!validator.IsLoginValid(user)) { return false; }
            else { return true; }
        }
    }
}
