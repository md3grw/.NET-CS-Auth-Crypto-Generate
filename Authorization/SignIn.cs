//Login
using SilevenText.Entity;
using System;

namespace SilevenText.Authorization
{
    internal class SignIn
    {
        public bool Login(User user)
        {
            if (!Validator.IsValid(user))
            {
                //something went wrong with sign in function! Try again or use registration function
                return false;
            }
            else
            {
                //continue
                return true;
            }
        }
    }
}
